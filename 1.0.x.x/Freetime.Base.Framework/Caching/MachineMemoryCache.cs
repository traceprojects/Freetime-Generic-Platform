using System;
using System.Collections.Generic;

namespace Freetime.Base.Framework.Caching
{
    internal class MachineMemoryCache : Cache
    {
        private Dictionary<string, object> m_cachedObjects;

        private Dictionary<string, object> CachedObjects
        {
            get 
            { 
                m_cachedObjects = m_cachedObjects ?? new Dictionary<string, object>();
                return m_cachedObjects;
            }
        }

        public MachineMemoryCache(string name)
            : base(name)
        {
        }

        public MachineMemoryCache()
            : base(Guid.NewGuid().ToString())
        {
        }


        public override object Get(string key)
        {
            return this[key];
        }

        public override void Put(string key, object value)
        {
            if(Equals(key, null))
                throw new ArgumentNullException("key");
            this[key] = value;
        }

        public override object this[string key]
        {
            get
            {
                return !CachedObjects.ContainsKey(key)
                    ? null
                    : CachedObjects[key];
            }
            set
            {
                if (!CachedObjects.ContainsKey(key))
                    CachedObjects.Add(key, value);
                else
                    CachedObjects[key] = value;
            }
        }

        public override bool ContainsKey(string key)
        {
            return CachedObjects.ContainsKey(key);
        }

    }
}
