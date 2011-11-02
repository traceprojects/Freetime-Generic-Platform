using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using Freetime.Base.Data.Collection.Common;
using Freetime.Base.Data.Entities;

namespace Freetime.Base.Data.Collection
{
    [Serializable]
    [CollectionDataContract]
    [XmlRoot("LanguageResources",
        Namespace = "http://www.freetime-generic.com",
        IsNullable = true)]
    public class LanguageResourceCollection : DictionaryList<string, LanguageResource>
    {
        protected override string GetKeyValue(LanguageResource item)
        {
            return item.ResourceKey;
        }
    }
}
