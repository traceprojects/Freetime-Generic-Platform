using System;
using Freetime.Base.Data.Contracts;
using Freetime.Base.Data.Entities;
using Freetime.Base.Data.Collection;

namespace Freetime.Base.Data
{
    public class ApplicationConfigurationSession : DataSession, IApplicationConfigurationSession
    {
        public ConfigurationItemCollection GetAllConfigurations()
        {
            return CurrentSession.GetList<ConfigurationItemCollection, ConfigurationItem>();
        }

        public ConfigurationItem GetConfigurationItem(string configName)
        {
            if (Equals(configName, null))
                throw new ArgumentNullException("configName");
            return CurrentSession.GetT<ConfigurationItem>(x => x.ConfigName == configName);
        }

        public void SaveConfigurationItem(ConfigurationItem configItem)
        {
            if (Equals(configItem, null))
                throw new ArgumentNullException("configItem");
            CurrentSession.Save(configItem);
        }

        public void DeleteConfigurationItem(ConfigurationItem configItem)
        {
            if (Equals(configItem, null))
                throw new ArgumentNullException("configItem");
            CurrentSession.Delete(configItem);
        }
    }
}
