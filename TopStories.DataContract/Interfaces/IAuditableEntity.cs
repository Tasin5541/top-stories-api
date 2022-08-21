using System;

namespace TopStories.DataContract.Interfaces
{
    public interface IAuditableEntity
    {

        DateTime CreateTime { get; set; }

        DateTime LastModifiedTime { get; set; }
    }
}
