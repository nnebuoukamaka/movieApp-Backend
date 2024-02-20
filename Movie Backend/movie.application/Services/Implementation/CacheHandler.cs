using Microsoft.Extensions.Caching.Memory;
using movie.application.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movie.application.Services.Implementation
{
    public class CacheHandler : ICacheHandler
    {
        private readonly IMemoryCache _cache;

        public CacheHandler(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void SaveSearchQuery(string query)
        {
            var queriesFromCache = _cache.Get<List<string>>("movies");

            if (queriesFromCache == null || !queriesFromCache.Any())
            {
                _cache.Set<List<string>>("movies", new List<string> { query });
            }

            else if (queriesFromCache.Count > 0 && queriesFromCache.Count < 5)
            {
                queriesFromCache.Add(query);
                _cache.Set<List<string>>("movies", queriesFromCache);
            }

            else
            {
                queriesFromCache.RemoveAt(0);
                queriesFromCache.Add(query);
                _cache.Set<List<string>>("movies", queriesFromCache);
            }
        }
    }
}
