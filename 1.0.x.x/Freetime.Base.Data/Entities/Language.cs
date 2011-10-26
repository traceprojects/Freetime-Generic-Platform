using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using Freetime.Base.Data.Entities.Common;
using Freetime.Base.Data.Collection;
using Anito.Data;

namespace Freetime.Base.Data.Entities
{
    [DataContract]
    [Serializable]
    [XmlRoot("Language",
        Namespace = "http://www.freetime-generic.com",
        IsNullable = true)]
    public class Language : AuditableEntity
    {
        [DataMember]
        [XmlElement("ID")]
        public Int64 ID
        {
            get;
            protected set;
        }
       
        [DataMember]
        [XmlElement("LanguageCode")]
        public string LanguageCode { get; set; }

        [DataMember]
        [XmlElement("DisplayName")]
        public string DisplayName { get; set; }

        [DataMember]
        [XmlElement("IsActive")]
        public bool IsActive { get; set; }

        #region LanguageResource
        private DataObjectSet<LanguageResourceCollection, LanguageResource> m_languageResources;

        [DataMember]
        [XmlElement("Resources")]
        public virtual LanguageResourceCollection Resources
        {
            get { return m_languageResources.Details; }
        }
        #endregion

    }
}
