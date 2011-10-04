using System;
using System.Xml.Serialization;
using Freetime.Base.Data.Entities.Common;
using System.Runtime.Serialization;

namespace Freetime.Base.Data.Entities
{
    [Serializable]
    [DataContract]
    [XmlRoot("ConfigurationItem",
        Namespace = "http://www.freetime-generic.com",
        IsNullable = true)]
    public class ConfigurationItem : AuditableEntity
    {
        [DataMember]
        [XmlElement("ID")]
        public Int64 ID
        {
            get;
            protected set;
        }

        [DataMember]
        [XmlElement("ConfigName")]
        public string ConfigName { get; set; }

        [DataMember]
        [XmlElement("ConfigValue")]
        public string ConfigValue { get; set; }

        [DataMember]
        [XmlElement("Type")]
        public string Type { get; set; }

        [DataMember]
        [XmlElement("ConfigGroup")]
        public string ConfigGroup { get; set; }

        [DataMember]
        [XmlElement("Description")]
        public string Description { get; set; }

    }
}
