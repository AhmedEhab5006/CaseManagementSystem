using Application.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.Services
{
    public class OTPCacheService : IOTPCache
    {
        private readonly IMemoryCache _memoryCache;

        public OTPCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void Set(string key, string value, TimeSpan expiration)
        {
            _memoryCache.Set(key, value, expiration);
        }

        public string? Get(string key)
        {
            return _memoryCache.TryGetValue(key, out string value) ? value : null;
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }
    }
}
