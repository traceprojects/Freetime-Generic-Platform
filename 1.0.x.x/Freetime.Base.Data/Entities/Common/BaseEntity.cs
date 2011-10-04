using System;
using System.Runtime.Serialization;

namespace Freetime.Base.Data.Entities.Common
{
    [Serializable]
    [DataContract]
    public abstract class BaseEntity : IDisposable
    {
        public virtual void Dispose()
        {
        }

    }
}
