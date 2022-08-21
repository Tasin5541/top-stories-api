using Microsoft.EntityFrameworkCore;

namespace TopStories.Persistence
{
    public class TsDbContextFactory : DesignTimeDbContextFactoryBase<TsDbContext>
    {
        protected override TsDbContext CreateNewInstance(DbContextOptions<TsDbContext> options)
        {
            return new TsDbContext(options);
        }
    }
}
