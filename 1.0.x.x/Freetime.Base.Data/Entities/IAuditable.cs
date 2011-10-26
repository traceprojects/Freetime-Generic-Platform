using System;

namespace Freetime.Base.Data.Entities
{
    public interface IAuditable
    {
        Int64? UserCreated { get; set; }
        DateTime? DateCreated { get; set; }
        Int64? UserModified { get; set; }
        DateTime? DateModified { get; set; }
    }
}
