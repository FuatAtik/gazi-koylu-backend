using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Taigate.Data.Data;
using Taigate.Data.Data.Entities;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using RazorLight;
using Taigate.Cms.Infrastructure;
using Taigate.Cms.Models;
using Taigate.Core;
using Taigate.Core.Cache;
using Taigate.Data.Service;
using Taigate.Mongo.Models;
using Taigate.Mongo.Repositories;
using Taigate.Mongo.Services;

namespace Taigate.Cms.Services
{
    public class CustomDbCache : ICustomDbCache
    {
        private readonly AppDbContext _dbContext;
        private readonly IRenderService _renderService;
        private readonly IPageCacheRepository _pageCacheMongo;
        private readonly ISearchCacheRepository _searchCacheMongo;
        private readonly ISearchStringCacheRepository _searchStringCacheMongo;

        public CustomDbCache(IMongoDataService mongoData, AppDbContext dbContext, IRenderService renderService)
        {
            _dbContext = dbContext;
            _renderService = renderService;
            _pageCacheMongo = mongoData.PageCaches;
            _searchCacheMongo = mongoData.SearchCaches;
            _searchStringCacheMongo = mongoData.SearchStringCaches;
        }

        private async Task DeleteAllRows<T>(DbSet<T> dbSet) where T : class
        {
            if (dbSet.Any())
            {
                dbSet.RemoveRange(dbSet.ToList());
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task ClearPageCache()
        {
            var dbCacheEntity = _dbContext.DbCache;
            await DeleteAllRows(dbCacheEntity);
            await _pageCacheMongo.DeleteAllPageCacheAsync();
        }

        public async Task ClearSearchCache()
        {
            var searchCacheEntity = _dbContext.SearchCache;
            await DeleteAllRows(searchCacheEntity);
            var searchTermCacheEntity = _dbContext.SearchTermCache;
            await DeleteAllRows(searchTermCacheEntity);
            await _searchCacheMongo.DeleteAllSearchCacheAsync();
            await _searchStringCacheMongo.DeleteAllSearchStringCacheAsync();

        }

        public async Task<string> GetOrCreateDbCache(UrlRecord record)
        {
            try
            {
                var cacheEntity = _dbContext.Set<DbCache>().FirstOrDefault(x => x.CacheKey == record.Id);
                if (cacheEntity != null)
                {
                    var cacheCshtml = cacheEntity.CacheCshtml;
                    return !string.IsNullOrEmpty(cacheCshtml) ? cacheCshtml : "";
                }

                var result = await _renderService.CompileRenderString(record.Slug,record.CsHtml, new { });
                var componentNames = _renderService.GetComponentNames(record.CsHtml);
                result = await _renderService.RenderViewComponents(componentNames, result, record.LanguageId, siteId: record.SiteId,
                    urlRecord: record);

                var localizedModels = _renderService.GetLocalizedModel(result);
                result = await _renderService.RenderLocalized(localizedModels, result, record.LanguageId, siteId: record.SiteId);

                await _dbContext.Set<DbCache>().AddAsync(new DbCache
                {
                    CacheKey = record.Id,
                    CacheCshtml = result,
                    Guid = new Guid()
                });
                await _dbContext.SaveChangesAsync();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "";
            }
        }

        public async Task<string> GetOrCreateSearchCache(UrlRecord record)
        {
            try
            {
                var cacheEntity = _dbContext.Set<SearchCache>().FirstOrDefault(x => x.PageSlug == record.Slug);
                if (cacheEntity != null)
                {
                    var cacheCshtml = cacheEntity.CacheCshtml;
                    return !string.IsNullOrEmpty(cacheCshtml) ? cacheCshtml : "";
                }
                
                var result =
                    await _renderService.CompileRenderString(record.Slug, record.CsHtml,
                        new { });
                var componentNames = _renderService.GetComponentNames(record.CsHtml);
                var excludedNames = componentNames
                    .Where(x => !x.ComponentName.StartsWith("Menu") && !x.ComponentName.StartsWith("Footer") &&
                                !x.ComponentName.StartsWith("Head") && !x.ComponentName.StartsWith("Google")).ToList();
                try
                {
                    result = await _renderService.RenderViewComponents(excludedNames, result, record.LanguageId,
                        siteId: record.SiteId, urlRecord: record);
                    var localizedModels = _renderService.GetLocalizedModel(result);
                    result = await _renderService.RenderLocalized(localizedModels, result, record.LanguageId, record,
                        record.SiteId);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return "";
                }

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "";
            }
        }

        public async Task<string> GetOrCreateSearchTermCache(string searchString, int languageId, int siteId)
        {
            try
            {
                var cacheKey = string.Format(TaigateDefaults.SearchTermCache, searchString, siteId, languageId);

                var cacheEntity = _dbContext.Set<SearchTermCache>().FirstOrDefault(x => x.SearchTerm == cacheKey);
                if (cacheEntity != null)
                {
                    var cacheCshtml = cacheEntity.CacheCshtml;
                    return !string.IsNullOrEmpty(cacheCshtml) ? cacheCshtml : "";
                }


                var searchModels = new List<SearchResults>();
                var urlRecord = await _dbContext.Set<UrlRecord>()
                    .FirstOrDefaultAsync(x => x.Slug == "aramasonuc" && x.SiteId == siteId);
                var cshtml = urlRecord.CsHtml;

                string result = await _renderService.CompileRenderString($"{searchString}-DontCache",cshtml, new { });
                List<ComponentModel> componentNames = _renderService.GetComponentNames(cshtml);

                var allUrlRecords = _dbContext.UrlRecord.Where(x =>
                        x.SiteId == siteId && x.IsActive && !x.Slug.Contains("-detay") &&
                        x.Slug != "pagenotfound" && x.Slug != "aramasonuc" && x.LanguageId == languageId)
                    .ToList();
                foreach (var record in allUrlRecords)
                {
                    try
                    {
                        var cacheEntry = GetOrCreateSearchCache(record).Result;
                        if (cacheEntry != null)
                        {
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }

                await _dbContext.SaveChangesAsync();
                result = await _renderService.RenderCustomViewComponents(componentNames, result, urlRecord,
                    searchModels.ToDynamicList(), languageId,  urlRecord.SiteId);
                var localizedModels = _renderService.GetLocalizedModel(result);
                result = await _renderService.RenderLocalized(localizedModels, result, languageId, urlRecord,
                    urlRecord.SiteId);


                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "";
            }
        }

        public async Task<string> GetOrCreateMongoPageCache(UrlRecord record)
        {
            
            try
            {
                var cacheEntity = _pageCacheMongo.GetFirstWithPageId(record.Id);
                if (cacheEntity != null)
                {
                    var cacheCshtml = cacheEntity.ResultCshtml;
                    return !string.IsNullOrEmpty(cacheCshtml) ? cacheCshtml : "";
                }

                var result = await _renderService.CompileRenderString(record.Slug,record.CsHtml, new { });
                var componentNames = _renderService.GetComponentNames(record.CsHtml);

                result = await _renderService.RenderViewComponents(componentNames, result, record.LanguageId, siteId: record.SiteId,
                    urlRecord: record);

                var localizedModels = _renderService.GetLocalizedModel(result);
                result = await _renderService.RenderLocalized(localizedModels, result,  record.LanguageId, record, record.SiteId);

                await _pageCacheMongo.CreatePageCacheAsync(new PageCacheDto
                {
                    PageId = record.Id,
                    Slug = record.Slug,
                    ResultCshtml = result
                });
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        public async void CreateMongoSearchCache(UrlRecord record,List<SearchResults> searchModels,string searchString)
        {
            try
            {
               
                var result =
                    await _renderService.CompileRenderString($"{searchString}-DontCache", record.CsHtml,
                        new { });
                var componentNames = _renderService.GetComponentNames(record.CsHtml);
                var excludedNames = componentNames
                    .Where(x => !x.ComponentName.StartsWith("Menu") && !x.ComponentName.StartsWith("Footer") &&
                                !x.ComponentName.StartsWith("Head") && !x.ComponentName.StartsWith("Google")).ToList();
                try
                {
                    result = await _renderService.RenderViewComponents(excludedNames, result, record.LanguageId,
                        siteId: record.SiteId, urlRecord: record);
                    var localizedModels = _renderService.GetLocalizedModel(result);
                    result = await _renderService.RenderLocalized(localizedModels, result, record.LanguageId, record,
                        record.SiteId);

                    var stripHtml = _renderService.StripHTML(result);
                    stripHtml = HttpUtility
                        .HtmlDecode(stripHtml); //bi önceki adımdan kaynaklı türkçe karakter bozulma sorunu için

                    var lower = stripHtml.ToLower();
                    var withoutSpacesHtml = Regex.Replace(lower, " {2,}", " ");
                    var startIndex = withoutSpacesHtml.IndexOf("header", StringComparison.Ordinal);
                    var endIndex = withoutSpacesHtml.IndexOf("footer", StringComparison.Ordinal);

                    await _searchCacheMongo.CreateSearchCacheAsync(new SearchCacheDto
                    {
                        PageName = record.PageName,
                        Slug = record.Slug,
                        StartIndex = startIndex,
                        EndIndex = endIndex,
                        ResultCshtml = withoutSpacesHtml,
                        LanguageId = record.LanguageId
                    });
                    
                    var searchCache = new Mongo.Entities.SearchCache()
                    {
                        PageName = record.PageName,
                        Slug = record.Slug,
                        StartIndex = startIndex,
                        EndIndex = endIndex,
                        ResultCshtml = withoutSpacesHtml,
                        LanguageId = record.LanguageId
                    };
                    
                    PrepareSearchModel(searchCache, searchModels, searchString);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public async Task<string> GetOrCreateMongoSearchStringCache(string searchString, int languageId,
            int siteId)
        {
            try
            {
                var cacheKey = string.Format(TaigateDefaults.SearchTermCache, searchString, siteId, languageId);

                var cacheEntity = _searchStringCacheMongo.GetFirstWithSearchString(cacheKey);
                if (cacheEntity != null)
                {
                    var cacheCshtml = cacheEntity.ResultCshtml;
                    return !string.IsNullOrEmpty(cacheCshtml) ? cacheCshtml : "";
                }

                var searchModels = new List<SearchResults>();
                var searchCaches = _searchCacheMongo.GetAll(languageId).ToList();
                if (searchCaches.Any())
                {
                    foreach (var searchCache in searchCaches)
                    {
                        PrepareSearchModel(searchCache, searchModels, searchString);
                    }
                }
                else
                {
                    var allUrlRecords = _dbContext.UrlRecord.Where(x =>
                            x.SiteId == siteId && x.IsActive && !x.Slug.Contains("-detay") &&
                            x.Slug != "pagenotfound" && x.Slug != "aramasonuc" && x.LanguageId == languageId)
                        .ToList();
                    foreach (var record in allUrlRecords)
                    {
                        try
                        {
                            var detailRecord = _dbContext.Set<UrlRecord>().FirstOrDefault(x => x.Slug == record.DetailSlug);
                            if (detailRecord != null)
                            {
                                record.CsHtml = detailRecord.CsHtml;
                            }
                            CreateMongoSearchCache(record,searchModels,searchString);
                            
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                }
                
                var searchListingPage = await _dbContext.Set<UrlRecord>()
                    .FirstOrDefaultAsync(
                        x => x.Slug == "aramasonuc" && x.SiteId == siteId && x.LanguageId == languageId);
                var cshtml = searchListingPage.CsHtml;

                string result = await _renderService.CompileRenderString($"{searchString}-DontCache",cshtml, new { });
                List<ComponentModel> componentNames = _renderService.GetComponentNames(cshtml);
                
                result = await _renderService.RenderCustomViewComponents(componentNames, result, searchListingPage,
                    searchModels.ToDynamicList(), languageId,  searchListingPage.SiteId);
                var localizedModels = _renderService.GetLocalizedModel(result);
                result = await _renderService.RenderLocalized(localizedModels, result, languageId, searchListingPage,
                    searchListingPage.SiteId);
                
                await _searchStringCacheMongo.CreateSearchStringCacheAsync(new SearchStringCacheDto
                {
                    SearchString = cacheKey,
                    ResultCshtml = result
                });
                
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "";
            }
        }


        public async void PrepareSearchModel(Mongo.Entities.SearchCache searchCache,
            List<SearchResults> searchModels, string searchString)
        {
            var resultCshtml = searchCache.ResultCshtml;
            //eğer footer varsa, footerdan sonraki karakterleri siliyorum
            if (searchCache.EndIndex > -1)
            {
                resultCshtml = resultCshtml.Substring(0, searchCache.EndIndex);
            }

            try
            {
                string text;
                var numberOfChar = 175; //kaç harf alınacak
                //aranan kelimeyi bulduğumuz ilk index
                var indexSearchString = resultCshtml.IndexOf(searchString,
                    searchCache.StartIndex > -1 ? searchCache.StartIndex : 250,
                    StringComparison.Ordinal);

                if (indexSearchString <= -1) return; //eğer kelime yoksa

                //eğer kelime varsa
                if (indexSearchString + numberOfChar > resultCshtml.Length)
                {
                    //büyük harfle başlıyorsa
                    if (char.IsUpper(resultCshtml.Substring(indexSearchString)[0]))
                    {
                        text = resultCshtml.Substring(indexSearchString, searchString.Length) +
                               "...";
                    }
                    //küçük harfle başlıyorsa
                    else
                    {
                        text = ".." + resultCshtml.Substring(indexSearchString, searchString.Length) +
                               "...";
                    }
                }
                else
                {
                    //büyük harfle başlıyorsa
                    if (char.IsUpper(resultCshtml.Substring(indexSearchString)[0]))
                    {
                        text = resultCshtml.Substring(indexSearchString, numberOfChar) +
                               "...";
                    }
                    //küçük harfle başlıyorsa
                    else
                    {
                        text = ".." + resultCshtml.Substring(indexSearchString, numberOfChar) +
                               "...";
                    }
                }

                if (text.Length < 25) return;

                //so i can delete html element on the frontend
                if (text.Contains("<") && !text.Contains(">"))
                {
                    text += ">...";
                }

                searchModels.Add(new SearchResults
                {
                    SubTitle = text,
                    Title = !string.IsNullOrEmpty(searchCache.PageName) ? searchCache.PageName : "link",
                    Url = searchCache.Slug, SearchString = searchString
                });
            }
            catch (Exception e)
            {
                return;
            }
        }
    }
}