using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TopStories.Domain.Entities;

namespace TopStories.Persistence.Configurations.Story
{
    public class MultiMediaConfiguration : IEntityTypeConfiguration<MultiMedia>
    {
        public void Configure(EntityTypeBuilder<MultiMedia> builder)
        {
            builder.ToTable(nameof(MultiMedia), "dbo");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Url).HasColumnType("nvarchar(250)").IsRequired();
            builder.Property(e => e.Type).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(e => e.CreateTime).HasColumnType("datetime").IsRequired().HasDefaultValueSql("getutcdate()");
            builder.Property(e => e.LastModifiedTime).HasColumnType("datetime").HasDefaultValueSql("getutcdate()");
        }
    }
}
