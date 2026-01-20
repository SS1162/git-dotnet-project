using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Services;
using System.Threading.Tasks;

namespace WebApiShope.MiddleWare
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RatingMiddleware
    {
        private readonly RequestDelegate _next;
       
        public RatingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IRatingsServise ratingsServise)
        {
           
            Rating rating = new Rating();
            rating.Host = Convert.ToString(httpContext.Request.Host);
            rating.Path = Convert.ToString(httpContext.Request.Path);
            rating.Method = Convert.ToString(httpContext.Request.Method);
            rating.Referer = Convert.ToString(httpContext.Request.Headers["Referer"]);
            rating.UserAgent = Convert.ToString(httpContext.Request.Headers["User-Agent"]);
            rating.RecordDate = DateTime.Now;
            await ratingsServise.AddRatingServise(rating);
             await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RatingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRatingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RatingMiddleware>();
        }
    }
}
