using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ExceptionMiddlewares
{
    public class SessionCheckMiddleware
    {
        private readonly RequestDelegate _next;

        public SessionCheckMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Exclude requests to the Auth/Account controller
            var path = context.Request.Path;

            if (path.StartsWithSegments("/Auth") || path.StartsWithSegments("/Api"))
            {
                await _next(context); // Bypass middleware for /Account paths
                return;
            }
            string sessionValue = context.Session.GetString("S_name");

            // Check if session value is null
            if (string.IsNullOrEmpty(sessionValue))
            {
                // Redirect to login if session value is null
                context.Response.Redirect("/Auth/Login");
                return;
            }

            // Proceed to the next middleware if session value exists
            await _next(context);
        }
    }
}
