using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CarRentals.Application.Interfaces;
using CarRentals.Attributes;
using CarRentals.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentals.Controllers
{
    [Area("Default")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        //public IActionResult Index() => View();

        [RequireUnauthenticated]
        public IActionResult Login(string returnUrl)
        {
            return new ChallengeResult(GoogleDefaults.AuthenticationScheme,
               new AuthenticationProperties
               {
                   RedirectUri = Url.Action(nameof(LoginCallback), new { returnUrl })
               });
        }

        [RequireUnauthenticated]
        public async Task<IActionResult> LoginCallback(string returnUrl)
        {
            var authenticateResult = await HttpContext.AuthenticateAsync("External");

            if (!authenticateResult.Succeeded)
                return BadRequest(); // TODO: Handle this better.

            var email = authenticateResult.Principal.FindFirst(ClaimTypes.Email).Value;
            var user = await _userService.GetUserByEmail(email);
            if (user == null)
                throw new InvalidOperationException($"The email does not exist in seed data: {email}"); // TODO: don't depend on seeded data

            var claimsIdentity = new ClaimsIdentity("Application");

            claimsIdentity.AddClaim(authenticateResult.Principal.FindFirst(ClaimTypes.NameIdentifier));
            claimsIdentity.AddClaim(authenticateResult.Principal.FindFirst(ClaimTypes.Email));

            claimsIdentity.AddClaim(new Claim(ClaimTypes.GivenName, user.FirstName));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Surname, user.LastName));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, user.Role));

            await HttpContext.SignInAsync(
                "Application",
                new ClaimsPrincipal(claimsIdentity));

            return LocalRedirect(returnUrl);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("Application");
            return LocalRedirect("/");
        }

        public IActionResult AccessDenied() => View();

        [Authorize]
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