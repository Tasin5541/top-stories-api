using System;
using System.Collections.Generic;
using System.Text;
using TopStories.DataContract.Dtos;

namespace TopStories.Application.Story.Queries.GetStoryList
{
    public class StoryDetail : TopStory
    {
        public List<MultiMedia> MultiMedia { get; set; }
    }
}
