using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TopStories.Application.Common.Interfaces;
using TopStories.Common;
using TopStories.DataContract.Interfaces;
using TopStories.Domain.Entities;

namespace TopStories.Persistence
{
    public class TsDbContext : DbContext, ITsDbContext
    {
        private readonly IDateTime _dateTime;

        public TsDbContext(DbContextOptions<TsDbContext> options)
            : base(options)
        {
        }

        public TsDbContext(
            DbContextOptions<TsDbContext> options, 
            IDateTime dateTime)
            : base(options)
        {
            _dateTime = dateTime;
        }
        public DbSet<TopStory> TopStories { get; set; }
        public DbSet<MultiMedia> MultiMedias { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreateTime = _dateTime.Now;
                        entry.Entity.LastModifiedTime = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedTime = _dateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TsDbContext).Assembly);
        }
    }
}
