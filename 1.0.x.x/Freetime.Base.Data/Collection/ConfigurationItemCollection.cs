using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Freetime.Base.Data.Entities;
using Freetime.Base.Data.Collection.Common;

namespace Freetime.Base.Data.Collection
{
    [Serializable]
    [CollectionDataContract]
    [XmlRoot("ConfigurationItems",
        Namespace = "http://www.freetime-generic.com",
        IsNullable = true)]
    public class ConfigurationItemCollection : DictionaryList<string, ConfigurationItem>
    {
        protected override string GetKeyValue(ConfigurationItem item)
        {
            return item.ConfigName;
        }
    }
}
