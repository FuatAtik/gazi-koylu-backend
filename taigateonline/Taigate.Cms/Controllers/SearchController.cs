using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using EFCoreSecondLevelCacheInterceptor;
using elFinder.NetCore.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RazorLight;
using Taigate.Cms.Infrastructure;
using Taigate.Cms.Models;
using Taigate.Core;
using Taigate.Core.Cache;
using Taigate.Data.Data;
using Taigate.Data.Data.Entities;
using Taigate.Data.Service;
using Taigate.Mongo.Models;
using Taigate.Mongo.Repositories;
using Taigate.Mongo.Services;

namespace Taigate.Cms.Controllers
{
    [Route("ara")]
    public class SearchController : Controller
    {
        private readonly ICustomDbCache _customDbCache;
        private IWorkContext _workContext;
        private AppDbContext _dbContext;
        private IRenderService _renderService;

        public SearchController(IWorkContext workContext, ICustomDbCache customDbCache, AppDbContext dbContext,
            IRenderService renderService)

        {
            _workContext = workContext;
            _customDbCache = customDbCache;
            _dbContext = dbContext;
            _renderService = renderService;
        }

        [HttpPost]
        [Route("")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Search(string searchTerm)
        {
            var siteId = Convert.ToInt16(CurrentSite.DoganlarMobilya);
            
            var language = await _workContext.GetWorkingLanguageAsync();
            var searchString = searchTerm.ToLower();
           
            var searchTermCache = _customDbCache.GetOrCreateMongoSearchStringCache(searchString, language.Id, siteId).Result;

            return View("~/Views/Home/DynamicPage.cshtml", searchTermCache);
        }


        [HttpPost]
        [Route("doganlarmobilya")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> GoogleCSE(string searchTerm, int pageIndex = 0)
        {   
            var siteId = Convert.ToInt16(CurrentSite.DoganlarMobilya);

            var language = await _workContext.GetWorkingLanguageAsync();
            var languageId = language.Id;
            var startIndex = pageIndex ==0 ? 0 : (pageIndex -1 ) * 10;
          
            var cx = "6d0a91daa48aeedc4";
            var apiKey = "AIzaSyA8p1eaQe6KGUFiTBhgj-g0meiAFkbNifs";
            var results = new List<Results>();
            try
            {
                var request = WebRequest.Create("https://www.googleapis.com/customsearch/v1?key=" + apiKey + "&cx=" +
                                                cx + "&q=" + searchTerm + "&start=" + startIndex);
                var response = (HttpWebResponse)request.GetResponse();
                var dataStream = response.GetResponseStream();
                var reader = new StreamReader(dataStream);
                var responseString = reader.ReadToEnd();
                dynamic jsonData = JsonConvert.DeserializeObject(responseString);

                int totalResults;
                try
                {
                    totalResults = (int)jsonData.queries.request[0].totalResults;
                }
                catch
                {
                    totalResults = 0;
                }

                if (jsonData.items != null)
                {
                    foreach (var item in jsonData.items)
                    {
                        results.Add(new Results
                        {
                            Title = item.title,
                            Link = item.link,
                            Snippet = item.snippet,
                        });
                    }
                }

                if(pageIndex > 0)   return Json(results);
                
                var searchResult = new GoogleSearchResults
                {
                    Results = results,
                    SearchTerm = searchTerm,
                    TotalResults = totalResults
                };
                
                var searchListingPage = await _dbContext.Set<UrlRecord>()
                    .FirstOrDefaultAsync(
                        x => x.Slug == "aramasonuc" && x.SiteId == siteId && x.LanguageId == languageId);
                var cshtml = searchListingPage.CsHtml;

                string result = await _renderService.CompileRenderString($"{searchTerm}-DontCache",cshtml, new { });
                List<ComponentModel> componentNames = _renderService.GetComponentNames(cshtml);

                result = await _renderService.RenderGoogleSearchPage(componentNames, result, searchListingPage,
                    searchResult, languageId, searchListingPage.SiteId);
                var localizedModels = _renderService.GetLocalizedModel(result);
                result = await _renderService.RenderLocalized(localizedModels, result, languageId, searchListingPage,
                    searchListingPage.SiteId);

                // if (pageIndex == 1)
                // {
                //     await _searchStringCacheRepository.CreateSearchStringCacheAsync(new SearchStringCacheDto
                //     {
                //         SearchString = searchTerm,
                //         ResultCshtml = result
                //     });
                // }

                return View("~/Views/Home/DynamicPage.cshtml", result);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Search didnt work properly!! See error :  {exception}");
                return Json(new {error= "An Error Occurred Check Your Search API"});
            }
        }
    }
}