using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentals.Middleware
{
    public abstract class BaseMiddleware
    {
        private readonly RequestDelegate _next;

        public BaseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Executes the next middleware in the pipeline.
        /// </summary>
        public Task Next(HttpContext context) => _next(context);

        public abstract Task Invoke(HttpContext context);

        public Task ExecuteViewAsync(HttpContext context, string viewName, object model = null, int statusCode = 200)
        {
            var result = new ViewResult()
            {
                StatusCode = statusCode,
                ViewName = viewName
            };

            var modelStateDictionary = new ModelStateDictionary();

            result.ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), modelStateDictionary)
            {
                Model = model
            };

            var routeData = new RouteData();
            var actionDescriptor = new ActionDescriptor();

            var actionContext = new ActionContext(context, routeData, actionDescriptor);
            return result.ExecuteResultAsync(actionContext);
        }
    }
}
