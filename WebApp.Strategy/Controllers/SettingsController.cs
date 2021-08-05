using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApp.Strategy.Entities;
using WebApp.Strategy.Models;

namespace WebApp.Strategy.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public SettingsController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            Settings settings = new();
            if (User.Claims.Where(p => p.Type == Settings.ClaimDatabaseType).FirstOrDefault() != null)
            {
                settings.DatabaseType = (EDatabaseType)int.Parse(User.Claims.First(x => x.Type == Settings.ClaimDatabaseType).Value);
            }
            else
            {
                settings.DatabaseType = settings.GetDefaultDatabaseType;
            }
            return View(settings);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeDatabase(int databaseType)
        {
            var user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            var claim = new Claim(Settings.ClaimDatabaseType, databaseType.ToString());
            var claims = await _userManager.GetClaimsAsync(user);
            var hasRelatedClaim = claims.FirstOrDefault(p => p.Type == Settings.ClaimDatabaseType);
            if (hasRelatedClaim != null)
            {
                await _userManager.ReplaceClaimAsync(user, hasRelatedClaim, claim);
                return RedirectToAction("Index");

            }
            await _userManager.AddClaimAsync(user, claim);
            var result = await HttpContext.AuthenticateAsync();

            await _signInManager.SignOutAsync();
            await _signInManager.SignInAsync(user, result.Properties);
            return RedirectToAction("Index");
        }
    }
}
