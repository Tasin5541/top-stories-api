using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TopStories.Application.Common.Interfaces;
using TopStories.Common;

namespace TopStories.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)//, IWebHostEnvironment environment)
        {
            services.AddTransient<IDateTime, MachineDateTime>();

            var sSharpEvaluator = new CSharpEvaluator();
            services.AddSingleton<ICSharpEvaluator>(sSharpEvaluator);

            return services;
        }
    }
}
