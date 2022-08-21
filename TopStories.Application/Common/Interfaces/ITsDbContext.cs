using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using TopStories.Domain.Entities;

namespace TopStories.Application.Common.Interfaces
{
    public interface ITsDbContext
    {
        DatabaseFacade Database { get; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbSet<TopStory> TopStories { get; set; }
        DbSet<MultiMedia> MultiMedias { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }

}
