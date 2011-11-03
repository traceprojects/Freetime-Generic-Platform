using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using Freetime.Base.Data.Entities.Common;

namespace Freetime.Base.Data.Entities
{
    [DataContract]
    [Serializable]
    [XmlRoot("LanguageResource",
        Namespace = "http://www.freetime-generic.com",
        IsNullable = true)]
    public class LanguageResource : AuditableEntity
    {
        [DataMember]
        [XmlElement("ID")]
        public Int64 ID { get; set; }

        [DataMember]
        [XmlElement("LanguageID")]
        public Int64 LanguageID { get; set; }

        [DataMember]
        [XmlElement("ResourceKey")]
        public string ResourceKey { get; set; }

        [DataMember]
        [XmlElement("Value")]
        public string Value { get; set; }

    }
}
