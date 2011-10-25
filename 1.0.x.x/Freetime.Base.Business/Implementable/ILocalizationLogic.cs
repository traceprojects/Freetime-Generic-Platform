using System;
using Freetime.Base.Data.Entities;
using Freetime.Base.Data.Collection;

namespace Freetime.Base.Business.Implementable
{
    public interface ILocalizationLogic : ILogic
    {
        Language NewLanguage();

        Language NewLanguage(string languageCode);

        Language GetLanguage(string languageCode);

        Language GetLanguage(Int64 languageId);

        void DeleteLanguage(Language language);

        void DeleteLanguage(string languageCode);

        void DeleteLanguage(Int64 languageId);

        LanguageList GetAllLanguage();

        void SaveLanguage(Language language);

    }
}
