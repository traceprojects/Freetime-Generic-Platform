using System;
using System.Collections.Generic;

namespace Freetime.Base.Framework.Caching
{
    internal class MachineMemoryCacheFactory : CacheFactory
    {
        private Dictionary<string, ICache> m_caches;

        private Dictionary<string, ICache> Caches
        {
            get 
            { 
                m_caches = m_caches ?? new Dictionary<string, ICache>();
                return m_caches;
            }
        }

        public override ICache GetCache(string name)
        {
            if(Equals(name, null))
                throw new ArgumentNullException("name");

            if(!Caches.ContainsKey(name))
            {
                ICache cache = new MachineMemoryCache(name);
                Caches.Add(name, cache);
            }
            return Caches[name];
        }

        public override ICache GetCache()
        {
            var cache = new MachineMemoryCache();
            Caches.Add(cache.Name, cache);
            return cache;
        }
    }
}
