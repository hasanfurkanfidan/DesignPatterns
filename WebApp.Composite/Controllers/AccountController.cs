using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Composite.Entities;

namespace WebApp.Composite.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser>userManager,SignInManager<AppUser>signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Login(string email,string password)
        {

            var hasUser = await _userManager.FindByEmailAsync(email);
            if (hasUser!=null)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(hasUser, password, true, true);
                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                return View();

            }
            return View();
        }
    }
}
