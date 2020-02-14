using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentals.Middleware
{
    public class ErrorPageMiddleware : BaseMiddleware
    {
        public ErrorPageMiddleware(RequestDelegate next) :
            base(next)
        {
        }

        public override async Task Invoke(HttpContext context)
        {
            await Next(context);

            var statusCode = context.Response.StatusCode;
            if (statusCode >= 400)
            {
                context.Response.Clear();
                await ExecuteViewAsync(context, "ErrorPageView", statusCode, statusCode);
            }
        }
    }
}
