using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Freetime.Deployment.Configuration.ApplicationConfiguration
{
    [Serializable]
    [XmlRoot("ApplicationConfiguration", 
        Namespace = "http://www.freetime-generic.com", 
        IsNullable = true)]
    public class ApplicationConfiguration
    {
        private List<ConfigGroup> m_configGroups;

        [XmlElement("ConfigGroup")]
        public List<ConfigGroup> ConfigGroups
        {
            get { m_configGroups = m_configGroups ?? new List<ConfigGroup>();
                return m_configGroups;
            }
            set { m_configGroups = value; }
        } 
    }
}
