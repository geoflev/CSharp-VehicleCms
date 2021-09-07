using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace VehicleCms.Common.Services.Decorators.Bases
{
    public abstract class DecoratorBase
    {
        public DecoratorBase(IDistributedCache distributedCache)
        {
            DistributedCache = distributedCache ?? throw new ArgumentNullException(nameof(distributedCache));
        }

        public abstract string CacheKeyBase { get; }
        public IDistributedCache DistributedCache { get; }

        public async Task<T> GetFromCacheOrHttp<T>(string cacheKey, Func<Task<T>> operation)
        {
            var cachedData = await DistributedCache.GetStringAsync(cacheKey);
            if (cachedData != null)
            {
                return JsonSerializer.Deserialize<T>(cachedData);
            }

            var response = await operation();
            cachedData = JsonSerializer.Serialize(response);
            await DistributedCache.SetStringAsync(cacheKey, cachedData);
            return response;
        }

        public async Task<string> GetFromCacheOrHttp(string cacheKey, Func<Task<string>> operation)
        {
            var cachedData = await DistributedCache.GetStringAsync(cacheKey);
            if (cachedData != null)
            {
                return cachedData;
            }

            cachedData = await operation();
            if (!string.IsNullOrWhiteSpace(cachedData))
            {
                await DistributedCache.SetStringAsync(cacheKey, cachedData);
            }
            return cachedData;
        }

        public async Task ClearCache(string cacheKey)
        {
            var cachedData = await DistributedCache.GetStringAsync(cacheKey);
            if (cachedData != null)
            {
                await DistributedCache.RemoveAsync(cacheKey);
            }
        }
    }
}
