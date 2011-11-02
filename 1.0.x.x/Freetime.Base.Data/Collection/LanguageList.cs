using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using Freetime.Base.Data.Entities;

namespace Freetime.Base.Data.Collection
{
    [Serializable]
    [CollectionDataContract]
    [XmlRoot("Languages",
        Namespace = "http://www.freetime-generic.com",
        IsNullable = true)]
    public class LanguageList : List<Language>
    {
    }
}
