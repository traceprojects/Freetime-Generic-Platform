using System.Collections.Generic;

namespace Freetime.Base.Framework.Caching
{
    public abstract class CacheFactory : ICacheFactory
    {
        private static Dictionary<string, CacheFactory> s_cacheFactories;
        private static ICacheFactory s_defaultCacheFactory;

        public static Dictionary<string, CacheFactory> Factories
        {
            get 
            { 
                s_cacheFactories = s_cacheFactories ?? GetFactories();
                return s_cacheFactories;
            }
            private set
            {
                s_cacheFactories = value;
            }
        }

        private static Dictionary<string, CacheFactory> GetFactories()
        {
            //TODO Get Cached
            return new Dictionary<string, CacheFactory>();
        }

        private static ICacheFactory GetDefaultCacheFactory()
        {
            Factories = GetFactories();

            //TODO check default
            return new MachineMemoryCacheFactory();
        }

        public static ICacheFactory Default
        {
            get
            {
                s_defaultCacheFactory = s_defaultCacheFactory ?? GetDefaultCacheFactory();
                return s_defaultCacheFactory;
            }
        }

        public abstract ICache GetCache(string name);

        public abstract ICache GetCache();
    }
}
