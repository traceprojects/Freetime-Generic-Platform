using System.Xml.Serialization;

namespace Freetime.Deployment.Configuration.Language
{
     [XmlRoot("Resource",
        Namespace = "http://www.freetime-generic.com",
        IsNullable = true)]
    public class LanguageResource
    {
        [XmlElement("Key")]
        public string ResourceKey { get; set; }

        [XmlElement("Value")] 
        public string Value { get; set; }
    }
}
