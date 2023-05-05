using Taigate.Crispy;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Taigate.Data.Data;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CrispyAdminConfigurationExtensions
    {
        public static string WebRootPath { get; private set; }
        public static string MapPath(string path, string basePath = null)
        {
            if (string.IsNullOrEmpty(basePath))
            {
                basePath = WebRootPath;
            }

            path = path.Replace("~/", "").TrimStart('/').Replace('/', Path.DirectorySeparatorChar);
            return Path.Combine(basePath, path);
        }
        public static void AddCrispyAdmin(this IServiceCollection services,string webRootPath, params string[] restrictToRoles)
        {
            services.AddTransient(services => new DiscoveredDbContextType() { Type = typeof(AppDbContext) }) ;

            if (restrictToRoles != null && restrictToRoles.Any())
            {
                var CrispyAdminSecurityOptions = new CrispyAdminSecurityOptions();
                CrispyAdminSecurityOptions.RestrictToRoles = restrictToRoles;
                services.AddSingleton(CrispyAdminSecurityOptions);
            }

            services.AddControllersWithViews();
            WebRootPath = webRootPath;
        }
    }
}
