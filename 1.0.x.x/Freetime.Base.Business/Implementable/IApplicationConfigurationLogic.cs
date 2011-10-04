using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Freetime.Base.Data.Entities;
using Freetime.Base.Data.Collection;

namespace Freetime.Base.Business.Implementable
{
    public interface IApplicationConfigurationLogic : ILogic
    {
        ConfigurationItemCollection GetAllConfigurations();

        ConfigurationItem GetConfigurationItem(string configName);

        void SaveConfigurationItem(ConfigurationItem configItem);

        void DeleteConfigurationItem(ConfigurationItem configItem);
    }
}
