using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentAll.Web.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AnalyticsMiddleware
    {
        private readonly RequestDelegate _next;

        public AnalyticsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AnalyticsMiddlewareExtensions
    {
        public static IApplicationBuilder UseAnalyticsMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AnalyticsMiddleware>();
        }
    }
}
