using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyLand.SiteEndPoint.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class GuestUserMiddleware
    {
        private readonly RequestDelegate _next;

        public GuestUserMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            //request
            var guestUserId = httpContext.Request.Cookies["GuestUserId"];
            if (guestUserId == null)
            {
                guestUserId = Guid.NewGuid().ToString();
                httpContext.Response.Cookies.Append("GuestUserId", guestUserId, new CookieOptions
                {
                    Path = "/",
                    HttpOnly = true,
                    Expires = DateTime.Now.AddDays(30)

                });
            }
            return _next(httpContext);
            //response
        }
    }


    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class GuestUserMiddlewareExtensions
    {
        public static IApplicationBuilder UseGuestUserMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GuestUserMiddleware>();
        }
    }
}
