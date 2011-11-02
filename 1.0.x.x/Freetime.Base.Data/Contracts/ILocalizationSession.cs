using System;
using System.ServiceModel;
using Freetime.Base.Data.Entities;
using Freetime.Base.Data.Collection;

namespace Freetime.Base.Data.Contracts
{
    [ServiceContract]
    public interface ILocalizationSession : IDataSession
    {
        [OperationContract(Name = "GetLanguageByLanguageCode")]
        Language GetLanguage(string languageCode);

        [OperationContract(Name = "GetLanguageById")]
        Language GetLanguage(Int64 languageId);

        [OperationContract(Name = "GetAllLanguage")]
        LanguageList GetAllLanguage();

        [OperationContract(Name = "SaveLanguage")]
        void SaveLanguage(Language language);

        [OperationContract(Name = "DeleteLanguage")]
        void DeleteLanguage(Language language);

        [OperationContract(Name = "DeleteLanguageByLanguageCode")]
        void DeleteLanguage(string languageCode);

        [OperationContract(Name = "DeleteLanguageById")]
        void DeleteLanguage(Int64 languageId);
    }
}
