using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TopStories.Application.Common.Interfaces;

namespace TopStories.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TsDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("TsDatabase")));

            services.AddScoped<ITsDbContext>(provider => provider.GetService<TsDbContext>());

            return services;
        }
    }
}
