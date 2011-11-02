using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace Freetime.Base.Data.Collection
{
    [Serializable]
    [CollectionDataContract]
    [XmlRoot("Controllers",
        Namespace = "http://www.freetime-generic.com",
        IsNullable = true)]
    public class WebControllerList : List<Entities.WebController>
    {        
    }
}
