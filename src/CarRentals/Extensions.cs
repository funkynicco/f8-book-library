using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    }
}
