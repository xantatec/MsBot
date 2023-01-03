using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace MsBot.Infrastructure
{
    public class CacheHelper
    {
        private static CacheHelper _instance;

        private CacheHelper()
        {
            var cacheOptions = Options.Create(new MemoryCacheOptions());
            LookupCache = new MemoryCache(cacheOptions);
        }

        private IMemoryCache LookupCache { get; set; }

        /// <summary>
        /// 实例
        /// </summary>
        public static CacheHelper Instance => _instance ??= new CacheHelper();

        public void Set<T>(object key, T obj)
        {
            LookupCache.Set(key, obj);
        }

        public bool TryGet<T>(object key, out T value)
        {
            return LookupCache.TryGetValue<T>(key, out value);
        }
    }
}
