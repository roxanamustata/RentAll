using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using RentAll.Domain.Models;
using RentAll.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


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

        public async Task Invoke(HttpContext httpContext, RentAllDbContext rentAllDbContext)
        {

            InspectRequest(httpContext.Request, rentAllDbContext);

            await _next(httpContext);
        }

        private void InspectRequest(HttpRequest request, RentAllDbContext rentAllDbContext)
        {


            request.Headers["Request-URL"] = request.GetDisplayUrl();
            request.Headers["Request-IP-Adress"] = request.HttpContext.Connection.RemoteIpAddress.ToString();
       
           


            var analytic = new WebAnalytic
            {
                //CreatedOn = DateTime.Now,
                RequestURL = request.Headers["Request-URL"],
                RequestIPAdress = request.Headers["Request-IP-Adress"],
                //IsRequestAuthenticated = request.HttpContext.User.Identity.IsAuthenticated,
                //ContentLength = (byte)request.ContentLength



            };
            using (rentAllDbContext)
            {
                rentAllDbContext.WebAnalytics.Add(analytic);
                rentAllDbContext.SaveChangesAsync();
            }
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