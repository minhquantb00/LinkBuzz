
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;

namespace LinkBuzz.Api.Services
{
    public class ResponseCacheService : IResponseCacheService
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        public ResponseCacheService(IDistributedCache distributedCache, IConnectionMultiplexer connectionMultiplexer)
        {
            _distributedCache = distributedCache;
            _connectionMultiplexer = connectionMultiplexer;
        }
        public Task<string> GetCacheResponseAsync(string cacheKey)
        {
            throw new NotImplementedException();
        }

        public async Task SetCacheResponseAsync(string cacheKey, object response, TimeSpan timeOut)
        {
            if (response == null) return;


        }
    }
}
