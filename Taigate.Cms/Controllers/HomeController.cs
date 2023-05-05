using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taigate.Data.Data;
using Taigate.Data.Data.Entities;
using Taigate.Cms.Infrastructure;
using Taigate.Core.Cache;
using System.IO;
using System.Text;
using Taigate.Core.Helpers;
using Taigate.Data.Service;

namespace Taigate.Cms.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IFileHelper _fileHelper;
        private readonly ICustomDbCache _customDbCache;
        private readonly IWorkContext _workContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(AppDbContext dbContext,
            IWorkContext workContext, IHttpContextAccessor httpContextAccessor, ICustomDbCache customDbCache, IFileHelper fileHelper)
        {
            _dbContext = dbContext;
            _workContext = workContext;
            _httpContextAccessor = httpContextAccessor;
            _customDbCache = customDbCache;
            _fileHelper = fileHelper;
        }

        [Route("/dynamicpagehack_beacuseparameteralwaysnull")]
        public async Task<IActionResult> DynamicPage(UrlRecord urlRecord,int languageId, string cachedHtml)
        {
            if (!string.IsNullOrEmpty(cachedHtml))
            {
                return View("~/Views/Home/DynamicPage.cshtml", cachedHtml);
            }
            
            var domain = _httpContextAccessor.HttpContext.Request.Host.Value;

            if (urlRecord.DetailSlug != null)
            {
                var detailRecord = _dbContext.Set<UrlRecord>().FirstOrDefault(x => x.Slug == urlRecord.DetailSlug);
                if (detailRecord != null)
                {
                    urlRecord.CsHtml = detailRecord.CsHtml;
                }
            }
            await _workContext.InitLanguageAsync(domain);
            string cacheEntry;
            
            try
            {
                cacheEntry = _customDbCache.GetOrCreateMongoPageCache(urlRecord).Result;
                _fileHelper.CreateHtml(cacheEntry,urlRecord.Slug);
            }
            catch (Exception e)
            {
                Console.WriteLine($"MONGO SERVICE NOT WORKIN: {e}");
                cacheEntry = _customDbCache.GetOrCreateDbCache(urlRecord).Result;
            }
            

            return View("~/Views/Home/DynamicPage.cshtml", cacheEntry);
        }
        
    }
}
