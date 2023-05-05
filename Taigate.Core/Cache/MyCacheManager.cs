using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace Taigate.Core.Cache
{
    public class MyCacheManager
    {
        private static readonly MemoryCache _cache = new(new MemoryCacheOptions());
        private readonly ConcurrentDictionary<object, SemaphoreSlim> _locks = new();
        
        public async Task<TItem> GetOrCreate<TItem>(object key, Func<Task<TItem>> createItem)
        {
            TItem cacheEntry;

            if (_cache.TryGetValue(key, out cacheEntry)) return cacheEntry;
            
            
            var mylock = _locks.GetOrAdd(key, k => new SemaphoreSlim(1, 1));
 
            await mylock.WaitAsync();
            try
            {
                if (!_cache.TryGetValue(key, out cacheEntry))
                {
                    // Key not in cache, so get data.
                    cacheEntry = await createItem();
                    _cache.Set(key, cacheEntry);
                }
            }
            finally
            {
                mylock.Release();
            }
            return cacheEntry;
        }
        
        public void Remove(object key)
        {
            _cache.Remove(key);
        }

        public void Clear()
        {
            foreach (var key in GetAllKeysList())
            {
                _cache.Remove(key);
            }

        }
        private static List<string> GetAllKeysList()
        {
            var field = typeof(MemoryCache).GetProperty("EntriesCollection", BindingFlags.NonPublic | BindingFlags.Instance);
            var collection = field.GetValue(_cache) as ICollection;
            var items = new List<string>();
            if (collection != null)
                foreach (var item in collection)
                {
                    var methodInfo = item.GetType().GetProperty("Key");
                    var val = methodInfo.GetValue(item);
                    items.Add(val.ToString());
                }
            return items;
        }
        
    }

}