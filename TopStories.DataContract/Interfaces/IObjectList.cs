using System.Collections.Generic;

namespace TopStories.DataContract.Interfaces
{
    public interface IObjectList<T>
    {
        IList<T> Results { get; set; }
    }
}
