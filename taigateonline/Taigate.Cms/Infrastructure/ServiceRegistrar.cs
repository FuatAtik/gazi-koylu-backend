using System;
using System.IO;
using EFCoreSecondLevelCacheInterceptor;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorLight.Caching;
using Taigate.Cms.Models;
using Taigate.Cms.Models.Validators;
using Taigate.Cms.Services;
using Taigate.Core;
using Taigate.Core.Cache;
using Taigate.Core.Data;
using Taigate.Core.Helpers;
using Taigate.Data.Data;
using Taigate.Data.Data.Entities;
using Taigate.Data.Service;
using Taigate.Mongo.Data;
using Taigate.Mongo.Repositories;
using Taigate.Mongo.Services;
using EmailModel = Taigate.Cms.Models.EmailModel;

namespace Taigate.Cms.Infrastructure
{
    public static class ServiceRegistrar
    {
        public static void ConfigureTaigate(this IServiceCollection services, string connectionString,string webRootPath)
        {
            services.AddSingleton<RequestTransformer>();
            services.AddSingleton<ICachingProvider,MemoryCachingProvider>();
            services.AddDbContext<AppDbContext>(option => option.UseSqlServer(connectionString, b => b.MigrationsAssembly("Taigate.Cms")),ServiceLifetime.Transient);
            services.AddSingleton<MongoContext>();
            services.AddSingleton<IFileHelper,ExtensionMethods>();
            
            services.AddScoped<IViewRenderService, ViewRenderService>();
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IWorkContext, WebWorkContext>();
            services.AddScoped<IGenericAttributeService, GenericAttributeService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IGeoLookupService, GeoLookupService>();
            services.AddScoped<IWebHelper, WebHelper>();
            services.AddScoped<ITaigateFileProvider, TaigateFileProvider>();
            services.AddScoped<IRenderService, RenderService>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);//We set Time here 
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            // services.AddSingleton<UserManager<User>,ExtendUserManager>();
            // services.AddCrispyAdmin(Environment.WebRootPath);
            services.AddCrispyAdmin(webRootPath,"God","Editor");


            services.AddIdentity<User, IdentityRole>().AddErrorDescriber<CustomIdentityErrorDescriber>()
                .AddUserManager<ExtendUserManager>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;

                options.Password.RequiredUniqueChars = 0;
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters =
                    "abcçdefghiıjklmnoöpqrsştuüvwxyzABCÇDEFGHIİJKLMNOÖPQRSŞTUÜVWXYZ0123456789-._@ ";
            });

            services.AddTransient<IValidator<EmailModel>, EmailModelValidator>();
            // services.Configure<MvcRazorRuntimeCompilationOptions>(opts => 
            //     opts.FileProviders.Add(
            //         new DatabaseFileProvider(Configuration.GetConnectionString("RepositoryDbConnection"))
            //     )
            // );
            services.AddHealthChecks();
            services.AddSingleton<ICustomCache, CustomMemoryCache>();
            services.AddSingleton<MyCacheManager>();
            services.AddScoped<ICustomDbCache, CustomDbCache>();
            services.AddScoped<IMongoDataService, MongoDataService>();
            
            services.AddDetection();
            
            services.AddHostedService<RunAtOnProjectStartService>();
        }
    }
}
