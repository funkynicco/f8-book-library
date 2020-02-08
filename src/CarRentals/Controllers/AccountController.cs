using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;

namespace CarRentals.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string returnUrl)
        {
            return new ChallengeResult(GoogleDefaults.AuthenticationScheme,
               new AuthenticationProperties
               {
                   RedirectUri = Url.Action(nameof(LoginCallback), new { returnUrl })
               });
        }

        public async Task<IActionResult> LoginCallback(string returnUrl)
        {
            var authenticateResult = await HttpContext.AuthenticateAsync("External");

            if (!authenticateResult.Succeeded)
                return BadRequest(); // TODO: Handle this better.

            var claimsIdentity = new ClaimsIdentity("Application");

            claimsIdentity.AddClaim(authenticateResult.Principal.FindFirst(ClaimTypes.NameIdentifier));
            claimsIdentity.AddClaim(authenticateResult.Principal.FindFirst(ClaimTypes.Email));

            await HttpContext.SignInAsync(
                "Application",
                new ClaimsPrincipal(claimsIdentity));

            return LocalRedirect(returnUrl);
        }

        public IActionResult Print()
        {
            var claims = new List<object>();
            foreach (var claim in User.Claims)
            {
                claims.Add(new
                {
                    claim.Issuer,
                    claim.Type,
                    claim.Value
                });
            }

            return Json(claims);
        }
    }
}