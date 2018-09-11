using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore;
using Microsoft.Extensions.Caching.Memory;

namespace MyHealth.Helpers
{
    public static class CacheHelper
    {
        public static void CreateSession(this IMemoryCache cache, string name, object value)
        {
            try
            {
                object response;
                if (cache.TryGetValue(name, out response))
                    cache.Remove(name);

                cache.Set(name, value);
            }
            catch (Exception)
            {
            }
        }

        public static object GetSession(this IMemoryCache cache, string name)
        {
            object response = null;
            cache.TryGetValue(name, out response);

            return response;
        }

    }
}
