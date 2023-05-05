using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EFCoreSecondLevelCacheInterceptor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Taigate.Cms.Controllers;
using Taigate.Core.Cache;
using Taigate.Core.Helpers;
using Taigate.Data.Data;
using Taigate.Data.Data.Entities;

namespace Taigate.Cms.Infrastructure
{
    public class RequestTransformer : DynamicRouteValueTransformer
    {
        private readonly IServiceProvider _provider;
        private readonly IFileHelper _fileHelper;

        public RequestTransformer(IServiceProvider provider, IFileHelper fileHelper)
        {
            _provider = provider;
            _fileHelper = fileHelper;
        }

        RouteValueDictionary NotFound(HttpContext httpContext, RouteValueDictionary values)
        {
            values["controller"] = "home";
            values["action"] = "error";
            httpContext.Response.StatusCode = (int) HttpStatusCode.NotFound;
            return values;
        }

        public override async ValueTask<RouteValueDictionary> TransformAsync(HttpContext httpContext,
            RouteValueDictionary values)
        {

            int detectedLanguageId = 0;

            var path = RequestHelper.GetRequestPath(httpContext.Request.Path.Value);
            if (path.Contains(".")) return values;
            switch (path)
            {
                case "serviceworker":
                    return values;
                case "hc":
                    return values;
            }

            if (path.Contains("Identity") || path.Contains("identity")) return values;
            
            var slugStr = values["slug"] as string;
            if (string.IsNullOrEmpty(path))
            {
                slugStr = "/";
            }

            var cachedHtmlFile = _fileHelper.ReadHtml(slugStr);
            if (!string.IsNullOrEmpty(cachedHtmlFile))
            {
                values["controller"] = "Home";
                values["action"] = "DynamicPage";
                values["cachedHtml"] = cachedHtmlFile;
                return values;
            }
            
            using var scope = _provider.CreateScope();
            var _dbContext = scope.ServiceProvider.GetService<AppDbContext>();
            var _cacheManager = scope.ServiceProvider.GetService<MyCacheManager>();
            var domain = httpContext.Request.Host.Value;
            

            var site = 
                await _cacheManager.GetOrCreate("CurrentSite", async () =>
                {
                    return await _dbContext.Set<Site>().FirstOrDefaultAsync(x => x.Domain.Contains(domain));
                });
            if (site == null)
                return values;
            var record = await _dbContext.Set<UrlRecord>()
                             .FirstOrDefaultAsync(x => x.Slug == slugStr && x.SiteId == site.Id) ??
                         await _dbContext.Set<UrlRecord>()
                             .FirstOrDefaultAsync(x => x.Slug == "pagenotfound" && x.SiteId == site.Id);
            if (record==null)
            {
                return values;
            }
            if (!record.IsActive)
            {
                record = await _dbContext.Set<UrlRecord>()
                    .FirstOrDefaultAsync(x => x.Guid == record.Guid && x.SiteId == site.Id && x.IsActive);
                if (record==null)
                {
                    record = await _dbContext.Set<UrlRecord>()
                        .FirstOrDefaultAsync(x => x.Slug == "pagenotfound" && x.SiteId == site.Id);
                }
                else
                {
                    httpContext.Response.Redirect(record.Slug, true);
                }
            }
            detectedLanguageId = record.LanguageId;

            values["id"] = record.Id;
            values["controller"] = record.Controller;
            values["action"] = record.Action;
            values["slug"] = slugStr;
            values["siteId"] = record.SiteId;
            values["languageId"] = detectedLanguageId;
      
            values["SeoTitle"] = record.SeoTitle;
            values["SeoDescription"] = record.SeoDescription;

            if (!string.IsNullOrEmpty(record.CsHtml))
                values["cshtml"] = record.CsHtml;

            if (string.IsNullOrEmpty(record.RouteKeys) || string.IsNullOrEmpty(record.RouteValues)) return values;
            values["routeKeys"] = record.RouteKeys;
            values["routeValues"] = record.RouteValues;
            values["dbSet"] = record.DbSet;
            values["detailSlug"] = record.DetailSlug;

            return values;
        }
    }
}
