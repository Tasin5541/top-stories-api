using TopStories.DataContract.Interfaces;
using System.Collections.Generic;

namespace TopStories.DataContract.Dtos
{
    public class ObjectListVm<T> : IObjectList<T>
    {
        public string Section { get; set; }
        public int TotalCount { get; set; }
        public IList<T> Results { get; set; }
    }
}
