using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TopStories.API.Controllers;
using TopStories.Application.Story.Queries.GetStoryList;
using TopStories.Common;
using TopStories.DataContract.Dtos;

namespace TopStories.Api.Controllers
{
    public class TopStoriesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ObjectListVm<StoryDetail>>> GetArtsStories()
        {
            var vm = await Mediator.Send(new GetStoryListQuery()
            {
                StoryType = (int)StoryTypes.Arts
            });

            return Ok(vm);
        }

        [HttpGet]
        public async Task<ActionResult<ObjectListVm<StoryDetail>>> GetHomeStories()
        {
            var vm = await Mediator.Send(new GetStoryListQuery()
            {
                StoryType = (int)StoryTypes.Home
            });

            return Ok(vm);
        }
        [HttpGet]
        public async Task<ActionResult<ObjectListVm<StoryDetail>>> GetScienceStories()
        {
            var vm = await Mediator.Send(new GetStoryListQuery()
            {
                StoryType = (int)StoryTypes.Science
            });

            return Ok(vm);
        }

        [HttpGet]
        public async Task<ActionResult<ObjectListVm<StoryDetail>>> GetUsStories()
        {
            var vm = await Mediator.Send(new GetStoryListQuery()
            {
                StoryType = (int)StoryTypes.Us
            });

            return Ok(vm);
        }

        [HttpGet]
        public async Task<ActionResult<ObjectListVm<StoryDetail>>> GetWorldStories()
        {
            var vm = await Mediator.Send(new GetStoryListQuery()
            {
                StoryType = (int)StoryTypes.World
            });

            return Ok(vm);
        }
    }
}
