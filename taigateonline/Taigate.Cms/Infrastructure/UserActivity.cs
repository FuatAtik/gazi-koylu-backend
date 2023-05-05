using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Taigate.Core.Cache;
using Taigate.Data.Data.Entities;

namespace Taigate.Cms.Infrastructure
{
    public class UserActivityMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly IServiceProvider _provider;


        public UserActivityMiddleware(IServiceProvider provider, RequestDelegate requestDelegate)
        {
            _provider = provider;
            _requestDelegate = requestDelegate;
        }
     
        public async Task Invoke(HttpContext context)
        {
            // using var scope = _provider.CreateScope();
            //
            // var _signInManager = scope.ServiceProvider.GetService<SignInManager<User>>();
            // var _userManager = scope.ServiceProvider.GetService<UserManager<User>>();
            // var _roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
            //
            // string visitorId = context.Request.Cookies["VisitorId"];
            // if (visitorId == null)
            // {
            //     var guid = Guid.NewGuid();
            //     bool isGuest = await _roleManager.RoleExistsAsync("Guest");
            //     if (!isGuest)
            //     {
            //         var roleGuest = new IdentityRole();
            //         roleGuest.Name = "Guest";
            //         await _roleManager.CreateAsync(roleGuest);
            //     }
            //
            //     var user = new User {UserName = guid + "@guest.crispy", Email = guid + "@guest.crispy",SystemGuid = guid};
            //
            //     var result = await _userManager.CreateAsync(user, guid.ToString());
            //     if (result.Succeeded)
            //     {
            //         await _userManager.AddToRoleAsync(user, "God");
            //     }
            //     context.Response.Cookies.Append("VisitorId", guid.ToString(), new CookieOptions()
            //     {
            //         Path = "/",
            //         HttpOnly = true,
            //         Secure = false,
            //     });
            // }

            await _requestDelegate(context);
        }
    }
}