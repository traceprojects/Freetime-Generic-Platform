using System;
using Freetime.Base.Data.Collection;
using Freetime.Base.Data.Contracts;
using Freetime.Base.Data.Entities;

namespace Freetime.Base.Data
{
    public class LocalizationSession : DataSession, ILocalizationSession
    {
        public Language GetLanguage(string languageCode)
        {
            if (Equals(languageCode, null))
                throw new ArgumentNullException("languageCode");

            return CurrentSession.GetT<Language>(l => l.LanguageCode == languageCode);
        }

        public Language GetLanguage(Int64 languageId)
        {
            if(Equals(languageId, null))
                throw new ArgumentNullException("languageId");

            return CurrentSession.GetT<Language>(l => l.ID == languageId);
        }

        public LanguageList GetAllLanguage()
        {
            return CurrentSession.GetList<LanguageList, Language>();
        }

        public void SaveLanguage(Language language)
        {
            if(Equals(language, null))
                throw new ArgumentNullException("language");

            CurrentSession.Save(language);
        }

        
        public void DeleteLanguage(Language language)
        {
            if (Equals(language, null))
                throw new ArgumentNullException("language");

            CurrentSession.Delete(language);
        }


        public void DeleteLanguage(string languageCode)
        {
            if (Equals(languageCode, null))
                throw new ArgumentNullException("languageCode");

            CurrentSession.Delete<Language>(l => l.LanguageCode == languageCode);
        }


        public void DeleteLanguage(Int64 languageId)
        {
            if (Equals(languageId, null))
                throw new ArgumentNullException("languageId");

            CurrentSession.Delete<Language>(l => l.ID == languageId);
        }

    }
}
