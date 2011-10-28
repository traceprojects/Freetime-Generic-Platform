using System.Collections.Generic;
using System.Xml.Serialization;

namespace Freetime.Deployment.Configuration.Language
{
    [XmlRoot("Language",
        Namespace = "http://www.freetime-generic.com", 
        IsNullable = true)]
    public class Language
    {
        private List<LanguageResource> m_languageResources;
        
        [XmlAttribute("LanguageCode")]
        public string LanguageCode { get; set; }

        [XmlAttribute("DisplayName")]
        public string DisplayName { get; set; }

        [XmlAttribute("Active")]
        public bool IsActive { get; set; }

        [XmlElement("Resource")]
        public List<LanguageResource> LanguageResources
        {
            get { m_languageResources = m_languageResources ?? new List<LanguageResource>();
                return m_languageResources;
            }
        }

    }
}
