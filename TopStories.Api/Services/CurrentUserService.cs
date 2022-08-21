using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using TopStories.Application.Common.Interfaces;

namespace TopStories.API.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            Profiles = JsonSerializer.Deserialize<int[]>(httpContextAccessor.HttpContext?.User?.FindFirstValue("profiles") ?? "[]");
            Permissions = JsonSerializer.Deserialize<int[]>(httpContextAccessor.HttpContext?.User?.FindFirstValue("permissions")??"[]");
            OrganizationId = System.Convert.ToInt32(httpContextAccessor.HttpContext?.User?.FindFirstValue("organizationid"));
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue("id");
            LanguageId = System.Convert.ToInt32(httpContextAccessor.HttpContext?.User?.FindFirstValue("languageid"));
            IsAuthenticated = UserId != null;
        }

        public int[] Profiles { get; set; }
        public int[] Permissions { get;}
        public int OrganizationId { get; }
        public string UserId { get; }

        public int LanguageId { get; }

        public bool IsAuthenticated { get; }
    }
}
