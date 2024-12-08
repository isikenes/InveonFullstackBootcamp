using Newtonsoft.Json;
using StackExchange.Redis;

namespace _3_LibraryAPI.Services
{
    public class RedisCacheService(IConnectionMultiplexer redis, IDatabase db)
    {
        private static readonly TimeSpan DefaultExpiry = TimeSpan.FromMinutes(10);

        public async Task<T?> GetAsync<T>(string key)
        {
            var value = await db.StringGetAsync(key);
            if (value.IsNullOrEmpty)
            {
                return default;
            }
            return JsonConvert.DeserializeObject<T>(value!);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan? expiry = null)
        {
            await db.StringSetAsync(key, JsonConvert.SerializeObject(value), expiry ?? DefaultExpiry);
        }

        public async Task RemoveAsync(string key)
        {
            await db.KeyDeleteAsync(key);
        }
    }
}
