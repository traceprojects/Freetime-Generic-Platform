using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Freetime.Deployment.Configuration.ApplicationConfiguration
{
    [Serializable]
    [XmlRoot("ConfigGroup",
        Namespace = "http://www.freetime-generic.com",
        IsNullable = true)]
    public class ConfigGroup
    {
        private List<Configuration> m_configurations;
            
        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlElement("Configuration")]
        public List<Configuration> Configurations
        {
            get { m_configurations = m_configurations ?? new List<Configuration>();
                return m_configurations;
            }
            set { m_configurations = value; }
        }
    }
}
