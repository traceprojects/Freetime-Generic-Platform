using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Freetime.Base.Data.Collection
{
    [Serializable]
    [CollectionDataContract]
    [XmlRoot("WebThemes",
        Namespace = "http://www.freetime-generic.com",
        IsNullable = true)]
    public class WebThemeList : List<Entities.WebTheme>
    {
    }
}
