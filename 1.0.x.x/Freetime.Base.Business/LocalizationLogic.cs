using System;
using Freetime.Base.Business.Implementable;
using Freetime.Base.Data;
using Freetime.Base.Data.Contracts;
using Freetime.Base.Data.Entities;
using Freetime.Base.Data.Collection;

namespace Freetime.Base.Business
{
    public class LocalizationLogic : BaseLogic<ILocalizationSession>, ILocalizationLogic
    {
        #region DefaultSession
        protected override ILocalizationSession DefaultSession
        {
            get{ return new LocalizationSession(); }
            
        }
        #endregion

        #region NewLanguage
        public Language NewLanguage()
        {
            return NewLanguage(string.Empty);
        }

        public Language NewLanguage(string languageCode)
        {
            if(Equals(languageCode, null))
                throw new ArgumentNullException("languageCode");

            var language = new Language {LanguageCode = languageCode};
            return language;
        }
        #endregion

        #region GetLanguage
        public Language GetLanguage(string languageCode)
        {
            if(Equals(languageCode, null))
                throw new ArgumentNullException("languageCode");

            return CurrentSession.GetLanguage(languageCode);
        }

        public Language GetLanguage(Int64 languageId)
        {
            if (Equals(languageId, null))
                throw new ArgumentNullException("languageId");

            return CurrentSession.GetLanguage(languageId);
        }
        #endregion

        #region GetAllLanguage
        public LanguageList GetAllLanguage()
        {
            return CurrentSession.GetAllLanguage();
        }
        #endregion

        #region DeleteLanguage
        public void DeleteLanguage(Language language)
        {
            if (Equals(language, null))
                throw new ArgumentNullException("language");

            CurrentSession.DeleteLanguage(language);
        }

        public void DeleteLanguage(string languageCode)
        {
            if (Equals(languageCode, null))
                throw new ArgumentNullException("languageCode");

            CurrentSession.DeleteLanguage(languageCode);
        }

        public void DeleteLanguage(Int64 languageId)
        {
            if (Equals(languageId, null))
                throw new ArgumentNullException("languageId");

            CurrentSession.DeleteLanguage(languageId);

        }
        #endregion

        #region SaveLanguage
        public void SaveLanguage(Language language)
        {
            if(Equals(language, null))
                throw new ArgumentNullException("language");

            CurrentSession.SaveLanguage(language);
        }
        #endregion

    }
}
