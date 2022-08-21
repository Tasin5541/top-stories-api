using System;
using TopStories.DataContract.Interfaces;

namespace TopStories.Domain.Entities
{
    public class MultiMedia : IAuditableEntity
    {
        public int Id { get; set; }
        public int StoryId { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastModifiedTime { get; set; }
        public TopStory TopStory { get; set; }
    }
}
