using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml.FormulaParsing.Utilities;
using Taigate.Core.Cache;
using Taigate.Core.Helpers;
using Taigate.Crispy.ViewModels;
using Taigate.Data.Data.Entities;
using Taigate.Data.Service;

namespace Taigate.Crispy.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly ExtendUserManager _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly MyCacheManager _cacheManager;
        private readonly ICustomDbCache _customDbCache;
        private readonly IFileHelper _fileHelper;

        public AccountController(SignInManager<User> signInManager,
            ExtendUserManager userManager, RoleManager<IdentityRole> roleManager, MyCacheManager cacheManager, ICustomDbCache customDbCache, IFileHelper fileHelper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _cacheManager = cacheManager;
            _customDbCache = customDbCache;
            _fileHelper = fileHelper;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel obj)
        {
            _userManager.GetUserId(_signInManager.Context.User);
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(obj.Email);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(obj.Email, obj.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "CrispyAdminHome");
                    }
                }

                ModelState.AddModelError("", "E-posta veya şifre hatalı.");
                return View(obj);
            }

            return View(obj);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(LoginViewModel obj)
        {
            if (ModelState.IsValid)
            {
                bool isGod = await _roleManager.RoleExistsAsync("God");
                bool isGuest = await _roleManager.RoleExistsAsync("Guest");
                if (!isGod && isGuest)
                {
                    var roleGod = new IdentityRole();
                    roleGod.Name = "God";  
                    var roleGuest = new IdentityRole();
                    roleGuest.Name = "Guest";
                    await _roleManager.CreateAsync(roleGod);
                    await _roleManager.CreateAsync(roleGuest);
                }

                var user = new User {UserName = obj.Email, Email = obj.Email};

                var result = await _userManager.CreateAsync(user, obj.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "God");
                    return RedirectToAction("Login");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(obj);
            }

            return View(obj);
        }

        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(user);
            return RedirectToAction("UserList");
        }

        public IActionResult UserList()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        public IActionResult CreateUser()
        {
            return View(new UserViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserViewModel obj)
        {
            if (ModelState.IsValid)
            {
                bool x = await _roleManager.RoleExistsAsync("God");
                if (!x)
                {
                    var role = new IdentityRole();
                    role.Name = "God";
                    await _roleManager.CreateAsync(role);
                }

                var user = new User {UserName = obj.Email, Email = obj.Email};

                var result = await _userManager.CreateAsync(user, obj.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "God");
                    return RedirectToAction("UserList");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(obj);
            }

            return View(obj);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        public async Task<IActionResult> ClearCache()
        {
            _cacheManager.Clear();
            _fileHelper.DeleteAllHtmls();
            await _customDbCache.ClearPageCache();
            var referrerUrl = Request.Headers["Referer"].ToString();
            return Redirect(referrerUrl);
        }
        
        
        public async Task<IActionResult> ClearSearchCache()
        {
            await _customDbCache.ClearSearchCache();
            return RedirectToAction("Index", "CrispyAdminHome");
        }
    }
}
