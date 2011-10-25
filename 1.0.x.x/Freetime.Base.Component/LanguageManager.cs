using Freetime.Base.Data.Collection;
using Freetime.Base.Business;

namespace Freetime.Base.Component
{
    public class LanguageManager : ILanguageManager
    {
        private LanguageList m_languages;
        private LocalizationLogic m_logic;

        private LocalizationLogic CurrentLogic
        {
            get 
            { 
                m_logic = m_logic ?? new LocalizationLogic();
                return m_logic;
            }
        }
        public LanguageList Languages
        {
            get 
            { 
                m_languages = m_languages ?? CurrentLogic.GetAllLanguage();
                return m_languages;
            }
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
