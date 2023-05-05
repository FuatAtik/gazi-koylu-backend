using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Taigate.Cms.Infrastructure;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Taigate.Mongo;
using Taigate.Mongo.Data;

namespace Taigate.Cms
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment  Environment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("RepositoryDbConnection");
            services.Configure<DatabaseSettings>(
                Configuration.GetSection("MongoConnection"));
            
            services.ConfigureTaigate(connectionString,Environment.WebRootPath);
            //Smtp Configuration Yandex -- ready to use
            SmtpClient client = new SmtpClient("smtp.yandex.ru", 587);
            client.Credentials = new NetworkCredential("fuat@grouptaiga.com", "v.q-zjXJFcg.78.");
            client.EnableSsl = true;
            services
                .AddFluentEmail("fuat@grouptaiga.com")
                .AddSmtpSender(client);
            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            //app.UseHttpsRedirection();
            app.UseDetection();
            app.UseSession();

            app.UseStaticFiles();
            app.UseHealthChecks("/hc");
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseMiddleware(typeof(UserActivityMiddleware));

            app.UseStatusCodePages(context => {
                var response = context.HttpContext.Response;
                if (response.StatusCode == (int)HttpStatusCode.Unauthorized ||
                    response.StatusCode == (int)HttpStatusCode.Forbidden)
                    response.Redirect("/Account/Login");
                return Task.CompletedTask;
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=DynamicPage}/{id?}");
            });
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDynamicControllerRoute<RequestTransformer>("{**slug}");
            });
            
        }
    }
}
