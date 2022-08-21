using System;
using System.Collections.Generic;
using TopStories.DataContract.Interfaces;

namespace TopStories.Domain.Entities
{
    public class TopStory: IAuditableEntity
    {
        public int Id { get; set; }
        public string Section { get; set; }
        public string SubSection { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Url { get; set; }
        public string Byline { get; set; }
        public int Type { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastModifiedTime { get; set; }
        public virtual ICollection<MultiMedia> MultiMedias { get; set; }
    }
}
