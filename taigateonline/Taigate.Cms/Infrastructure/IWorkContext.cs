using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Taigate.Core;
using Taigate.Core.Cache;
using Taigate.Data.Data.Entities;
using Taigate.Data.Service;
using Wangkanai.Detection.Services;

namespace Taigate.Cms.Infrastructure
{
    public interface IWorkContext
    {
        public Task<User> GetCurrentUserAsync();
        public int GetRequestLanguageId();
        public Task<Language> GetWorkingLanguageAsync();
        public Task<bool> SetWorkingLanguageAsync(int id,string pref);
        public Task<bool> InitLanguageAsync(string domain = "");

    }

    public sealed class WebWorkContext : IWorkContext
    {
        private readonly IGenericAttributeService _genericAttributeService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDetectionService _detectionService;
        private readonly ExtendUserManager _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILanguageService _languageService;
        private readonly IGeoLookupService _geoLookupService;
        private readonly IWebHelper _webHelper;
        private ICustomCache _cacheManager;
        private User _cachedUser;

        public WebWorkContext(IGenericAttributeService genericAttributeService,
            IHttpContextAccessor httpContextAccessor, IDetectionService detectionService, ExtendUserManager userManager,
            SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager,ILanguageService languageService,IGeoLookupService geoLookupService,IWebHelper webHelper)
        {
            _genericAttributeService = genericAttributeService;
            _httpContextAccessor = httpContextAccessor;
            _detectionService = detectionService;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _geoLookupService = geoLookupService;
            _webHelper = webHelper;
            _languageService = languageService;
        }

        private string GetCustomerCookie()
        {
            var cookieName = $"{TaigateDefaults.Prefix}{TaigateDefaults.CustomerCookie}";
            return _httpContextAccessor.HttpContext?.Request?.Cookies[cookieName];
        }

        private void SetCustomerCookie(Guid userGuid)
        {
            if (_httpContextAccessor.HttpContext?.Response == null)
                return;

            //delete current cookie value
            var cookieName = $"{TaigateDefaults.Prefix}{TaigateDefaults.CustomerCookie}";
            _httpContextAccessor.HttpContext.Response.Cookies.Delete(cookieName);

            //get date of cookie expiration
            var cookieExpires = 24 * 365;
            var cookieExpiresDate = DateTime.Now.AddHours(cookieExpires);

            //if passed guid is empty set cookie as expired
            if (userGuid == Guid.Empty)
                cookieExpiresDate = DateTime.Now.AddMonths(-1);

            //set new cookie value
            var options = new CookieOptions
            {
                HttpOnly = true,
                Expires = cookieExpiresDate
            };
            _httpContextAccessor.HttpContext.Response.Cookies.Append(cookieName, userGuid.ToString(), options);
        }

        public async Task<User> GetCurrentUserAsync()
        {
            //whether there is a cached value
            if (_cachedUser != null)
                return _cachedUser;

            User user = null;

            //check whether request is made by a background (schedule) task
            // if (_httpContextAccessor.HttpContext == null ||
            //     _httpContextAccessor.HttpContext.Request.Path.Equals(new PathString($"/{NopTaskDefaults.ScheduleTaskPath}"), StringComparison.InvariantCultureIgnoreCase))
            // {
            //     //in this case return built-in customer record for background task
            //     customer = _customerService.GetCustomerBySystemName(NopCustomerDefaults.BackgroundTaskCustomerName);
            // }

            if (user == null)
            {
                //try for crawler
                if (_detectionService.Crawler.IsCrawler)
                    user = _userManager.GetUserBySystemName(TaigateDefaults.SearchEngineCustomerName);
            }

            if (user == null)
            {
                if (_httpContextAccessor.HttpContext.User.Identity.Name != null)
                {
                    //try to get registered user
                    var registeredUser =
                        await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);
                    user = registeredUser;
                }
    
            }

            if (user == null)
            {
                //get guest customer
                var customerCookie = GetCustomerCookie();
                if (!string.IsNullOrEmpty(customerCookie))
                {
                    if (Guid.TryParse(customerCookie, out Guid userGuid))
                    {
                        //get customer from cookie (should not be registered)
                        var customerByCookie = _userManager.GetUserByGuid(userGuid.ToString());
                        if (customerByCookie != null)
                            user = customerByCookie;
                    }
                }
            }

            if (user == null)
            {
                //create guest if not exists
                var guid = Guid.NewGuid();
                // bool isGuest = await _roleManager.RoleExistsAsync("Guest");
                // if (!isGuest)
                // {
                //     //not exist create it
                //     var roleGuest = new IdentityRole();
                //     roleGuest.Name = "Guest";
                //     await _roleManager.CreateAsync(roleGuest);
                // }

                var newUser = new User {UserName = guid + "@guest.crispy", Email = guid + "@guest.crispy", Guid = guid.ToString()};

                var result = await _userManager.CreateAsync(newUser, guid.ToString());
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newUser, "Guest");
                    await _signInManager.SignInAsync(newUser,false);
                    SetCustomerCookie(guid);
                }
                user = newUser;
            }
            _cachedUser = user;

            return _cachedUser;
        }
        public async Task<Language> GetWorkingLanguageAsync()
        {
            //get passed language identifier
            var user =await GetCurrentUserAsync();
            //get current saved language identifier
            var currentLanguageId = _genericAttributeService.GetIdentityUserAttribute<int>(user,@"LanguageId");
            var userLanguage = _languageService.GetAllLanguages().FirstOrDefault(language => language.Id == currentLanguageId);
            return userLanguage;
        }
        public async Task<bool> SetWorkingLanguageAsync(int id=0,string pref="")
        {
            //get passed language identifier
            var user =await GetCurrentUserAsync();
            if (id>0)
            {
                _genericAttributeService.SaveIdentityUserAttribute(user,@"LanguageId", id);
            }
            
            return true;
        }
        public async Task<bool> InitLanguageAsync(string domain="")
        {
            //get passed language identifier
            var user = await GetCurrentUserAsync();
            var currentLanguageId = _genericAttributeService.GetIdentityUserAttribute<int>(user,@"LanguageId");
            if (currentLanguageId == 0)
            {
                var language = _languageService.GetLanguageBySiteId(domain);
                _genericAttributeService.SaveIdentityUserAttribute(user,@"LanguageId", language.Id);
            }
            return true;
        }
        public int GetRequestLanguageId()
        {
            string requestIsoCode = _geoLookupService.LookupCountryIsoCode(GetRequestIpAddress());
            if (requestIsoCode == "TR")
            {
                return 1;
            }

            return 2;
        }
        public string GetRequestIpAddress()
        {
            string requestIpAddress = _webHelper.GetCurrentIpAddress();
            return requestIpAddress;
        }
      
    }
}