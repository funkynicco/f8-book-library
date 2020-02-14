using CarRentals.Application.Interfaces;
using CarRentals.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CarRentals
{
    public static class Extensions
    {
        public static async Task<bool> IsInPolicy(this ClaimsPrincipal principal, IAuthorizationService authService, string policy)
        {
            var result = await authService.AuthorizeAsync(principal, policy);
            return result.Succeeded;
        }

        public static async Task<User> GetCurrentUser(this HttpContext httpContext, IUserService userService)
        {
            // get logged in user email
            var email = httpContext.User.Claims.Where(a => a.Type == ClaimTypes.Email).FirstOrDefault().Value;

            // fetch the user by email
            return await userService.GetUserByEmail(email);
        }
    }
}
