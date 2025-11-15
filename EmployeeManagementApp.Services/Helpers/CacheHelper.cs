using System;
using System.Diagnostics;
using System.Runtime.Caching;

namespace EmployeeManagementApp.Services
{

    public static class CacheHelper
    {
        private static readonly MemoryCache _cache = MemoryCache.Default;

        public static T CachedLong<T>(string cacheKey, Func<T> getData)
        {
            if (string.IsNullOrWhiteSpace(cacheKey))
                throw new ArgumentException("Cache key cannot be null or empty", nameof(cacheKey));

            if (getData == null)
                throw new ArgumentNullException(nameof(getData));

            //Check if data exist in cache
            if (_cache.Contains(cacheKey))
            {
                Debug.WriteLine($"[CACHE HIT - Long] Key: {cacheKey}");
                return (T)_cache.Get(cacheKey);
            }
            //Data not in cache,retrive it
            Debug.WriteLine($"[CACHE MISS - Long] Key: {cacheKey} - Fetching fresh data...");
            var data = getData();
            // Store in cache with no expiration (until manually removed)
            var policy = new CacheItemPolicy
            {
                Priority = CacheItemPriority.Default
            };

            _cache.Set(cacheKey, data, policy);
            Debug.WriteLine($"[CACHE SET - Long] Key: {cacheKey} - Data cached indefinitely");

            return data;
        }

        public static T Cached<T>(string cacheKey, Func<T> getData)
        {
            if (string.IsNullOrWhiteSpace(cacheKey))
                throw new ArgumentException("Cache key cannot be null or empty", nameof(cacheKey));

            if (getData == null)
                throw new ArgumentNullException(nameof(getData));

            //Check if data exist in cache
            if (_cache.Contains(cacheKey))
            {
                Debug.WriteLine($"[CACHE HIT - 5min] Key: {cacheKey}");
                return (T)_cache.Get(cacheKey);
            }

            //Data not in cache,retrive it
            Debug.WriteLine($"[CACHE MISS - 5min] Key: {cacheKey} - Fetching fresh data...");
            var data = getData();

            // Store in cache with 5 minutes expiration
            var policy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5),
                Priority = CacheItemPriority.Default
            };

            _cache.Set(cacheKey, data, policy);
            Debug.WriteLine($"[CACHE SET - 5min] Key: {cacheKey} - Data cached for 5 minutes");

            return data;
        }
    }
}
