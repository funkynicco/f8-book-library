using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentals.Attributes
{
    /// <summary>
    /// Requires that a user is not authenticated to execute controller or action.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class RequireUnauthenticatedAttribute : Attribute, IFilterFactory
    {
        public bool IsReusable => true;

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider) => new RequireUnauthenticatedImpl();

        // Implementation

        private class RequireUnauthenticatedImpl : IActionFilter
        {
            public void OnActionExecuting(ActionExecutingContext context)
            {
                // if user is authenticated, we shortcircuit the action and return 404 not found
                if (context.HttpContext.User.Identity.IsAuthenticated)
                    context.Result = new NotFoundResult();
            }

            public void OnActionExecuted(ActionExecutedContext context)
            {
            }
        }
    }
}
