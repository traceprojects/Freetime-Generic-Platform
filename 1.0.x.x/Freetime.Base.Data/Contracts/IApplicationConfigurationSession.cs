using System;
using System.ServiceModel;
using Freetime.Base.Data.Entities;
using Freetime.Base.Data.Collection;

namespace Freetime.Base.Data.Contracts
{
    [ServiceContract]
    public interface IApplicationConfigurationSession : IDataSession
    {
        [OperationContract]
        ConfigurationItemCollection GetAllConfigurations();

        [OperationContract]
        ConfigurationItem GetConfigurationItem(string configName);

        [OperationContract]
        void SaveConfigurationItem(ConfigurationItem configItem);

        [OperationContract]
        void DeleteConfigurationItem(ConfigurationItem configItem);
    }
}
