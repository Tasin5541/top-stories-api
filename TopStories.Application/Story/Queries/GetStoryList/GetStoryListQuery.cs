using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using TopStories.Application.Common.Interfaces;
using TopStories.Common;
using TopStories.DataContract.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using System.Security.Policy;

namespace TopStories.Application.Story.Queries.GetStoryList
{
    public class GetStoryListQuery : IRequest<ObjectListVm<StoryDetail>>
    {
        public int StoryType { get; set; }
        public class Handler : IRequestHandler<GetStoryListQuery, ObjectListVm<StoryDetail>>
        {
            private readonly ITsDbContext _context;

            public Handler(ITsDbContext context)
            {
                _context = context;
            }

            public async Task<ObjectListVm<StoryDetail>> Handle(GetStoryListQuery request, CancellationToken cancellationToken)
            {
                var response = new ObjectListVm<StoryDetail>()
                {
                    Section = GetStoryTypeName(request.StoryType)
                };

                var StoryList = await _context.TopStories.Where(s => s.Type == request.StoryType).Include(s => s.MultiMedias)
                    .Select(s => new StoryDetail
                    {
                        Section = s.Section,
                        SubSection = s.SubSection,
                        Title = s.Title,
                        Abstract = s.Abstract,
                        Url = s.Url,
                        Byline = s.Byline,
                        MultiMedia = s.MultiMedias.Select(m => new MultiMedia
                        {
                            Url = m.Url,
                            Type = m.Type
                        }).ToList()
                    })
                    .ToListAsync();

                if (StoryList != null)
                {
                    response.Results = StoryList;
                    response.TotalCount = StoryList.Count;
                }

                return response;
            }

            public string GetStoryTypeName(int StoryType)
            {
                var StoryTypeName = "";

                switch (StoryType)
                {
                    case (int)StoryTypes.Arts:
                        StoryTypeName = "Arts";
                        break;

                    case (int)StoryTypes.Home:
                        StoryTypeName = "Home";
                        break;

                    case (int)StoryTypes.Science:
                        StoryTypeName = "Science";
                        break;

                    case (int)StoryTypes.Us:
                        StoryTypeName = "U.S. News";
                        break;

                    case (int)StoryTypes.World:
                        StoryTypeName = "World News";
                        break;

                    default:
                        break;
                }

                return StoryTypeName;
            }
        }
    }
}


