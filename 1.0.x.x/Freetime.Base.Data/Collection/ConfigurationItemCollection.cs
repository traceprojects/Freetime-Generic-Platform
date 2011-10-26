using Freetime.Base.Data.Entities;
using Freetime.Base.Data.Collection.Common;

namespace Freetime.Base.Data.Collection
{
    public class ConfigurationItemCollection : DictionaryList<string, ConfigurationItem>
    {
        protected override string GetKeyValue(ConfigurationItem item)
        {
            return item.ConfigName;
        }
    }
}
