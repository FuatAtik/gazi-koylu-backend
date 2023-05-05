using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
namespace Taigate.Cms.Infrastructure
{
    public class RedirectMiddleware
    {
        private readonly RequestDelegate _next;


        public RedirectMiddleware(RequestDelegate next, IServiceProvider provider)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            
            string slug = context.Request.Path.ToString();
            
            await _next.Invoke(context);
        }
    }

    public static class RedirectMiddlewareExtensions
    {
        public static IApplicationBuilder UseRedirect(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RedirectMiddleware>();
        }
    }
}