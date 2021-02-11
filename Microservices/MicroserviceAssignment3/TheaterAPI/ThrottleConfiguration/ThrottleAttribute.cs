using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TheaterAPI.ThrottleConfiguration
{
    public class ThrottleAttribute : ActionFilterAttribute
    {
        public string Name { get; set; }

        public int Seconds { get; set; }

        private static MemoryCache Cache { get; } = new MemoryCache(new MemoryCacheOptions());

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var ipAddress = context.HttpContext.Request.HttpContext.Connection.RemoteIpAddress;

            var memoryCacheKey = $"{Name}-{ipAddress}";

            if (!Cache.TryGetValue(memoryCacheKey, out bool entry))
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(Seconds));

                Cache.Set(memoryCacheKey, true, cacheEntryOptions);
            }
            else
            {
                context.Result = new ContentResult
                {
                    Content = $"Requests are limited to 1, every {Seconds} seconds.",
                };

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.TooManyRequests;
            }
        }
    }
}
