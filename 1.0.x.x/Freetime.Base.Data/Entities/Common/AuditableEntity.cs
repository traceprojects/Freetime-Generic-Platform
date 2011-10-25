using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace Freetime.Base.Data.Entities.Common
{
    [Serializable]
    [DataContract]
    public abstract class AuditableEntity : BaseEntity, IAuditable
    {
        [DataMember]
        [XmlElement("UserCreated")]
        public virtual Int64? UserCreated { get; set; }

        [DataMember]
        [XmlElement("UserModified")]
        public virtual Int64? UserModified { get; set; }

        [DataMember]
        [XmlElement("DateCreated")]
        public virtual DateTime? DateCreated { get; set; }

        [DataMember]
        [XmlElement("DateModified")]
        public virtual DateTime? DateModified { get; set; }

    }
}
