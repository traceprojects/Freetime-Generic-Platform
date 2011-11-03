using System;
using System.Xml.Serialization;

namespace Freetime.Deployment.Configuration.ApplicationConfiguration
{
    [Serializable]
    [XmlRoot("Configuration",
        Namespace = "http://www.freetime-generic.com",
        IsNullable = true)]
    public class Configuration
    {
        [XmlElement("ConfigName")]
        public string ConfigName { get; set; }

        [XmlElement("Description")]
        public string Description { get; set; }

        [XmlElement("ConfigValue")]
        public string ConfigValue { get; set; }

        [XmlElement("Type")]
        public string Type { get; set; }
    }
}
