using System;
using Freetime.Base.Data.Collection;
using Freetime.Base.Business;
using Freetime.Base.Framework.Caching;
using System.Linq;

namespace Freetime.Base.Component
{
    public class LanguageManager : ILanguageManager
    {
        private const string DEFAULT_CACHE_ID = "CCFE2526-7FB5-41D1-882D-58A063D23D09";
        private const string LANGUAGE_MANAGER_LANGUAGES = "LanguageManagerLanguages";

        private LocalizationLogic m_logic;
        private ICache m_cache;

        private LocalizationLogic CurrentLogic
        {
            get 
            { 
                m_logic = m_logic ?? new LocalizationLogic();
                return m_logic;
            }
        }

        private ICache CurrentCache
        {
            get 
            { 
                m_cache = m_cache ?? GetDefaultCache();
                return m_cache;
            }
        }

        private static ICache GetDefaultCache()
        {
            var cacheId = ApplicationConfigurationLogic.GetConfigString("LanguageManager.CacheId");
            if (string.IsNullOrEmpty(cacheId))
                cacheId = DEFAULT_CACHE_ID;

            var cacheFactoryId = ApplicationConfigurationLogic.GetConfigString("LanguageManager.CacheFactoryId");
            if (string.IsNullOrEmpty(cacheFactoryId))
                return CacheFactory.Default.GetCache(cacheId);

            var factory = CacheFactory.Factories[cacheFactoryId];

            if(Equals(factory, null))
                throw new Exception(string.Format("Undefine Cache Factory {0}", cacheFactoryId));

            return factory.GetCache(cacheId);
        }

        public virtual LanguageList Languages
        {
            get 
            { 
                if(!CurrentCache.ContainsKey(LANGUAGE_MANAGER_LANGUAGES))
                {
                    var languages = CurrentLogic.GetAllLanguage();
                    CurrentCache.Put(LANGUAGE_MANAGER_LANGUAGES, languages);
                }
                return CurrentCache.Get(LANGUAGE_MANAGER_LANGUAGES) as LanguageList;
            }
        }

        public virtual string GetStringResource(string languageCode, string key)
        {
            var language = Languages.FirstOrDefault(l => l.LanguageCode == languageCode);

            if (Equals(language, null))
                return string.Empty;

            var resource = language.Resources.FirstOrDefault(r => r.ResourceKey == key);

            return (Equals(resource, null))
                ? string.Empty
                : resource.Value;
        }

        #region Instance
        private static ILanguageManager s_instance;

        public static ILanguageManager Current
        {
            get 
            { 
                s_instance = s_instance ?? new LanguageManager();
                return s_instance;
            }
        }

        public static void SetLanguageManager(ILanguageManager manager)
        {
            s_instance = manager;
        }
        #endregion
    }
}
