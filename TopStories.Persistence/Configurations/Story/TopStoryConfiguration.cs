using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TopStories.Domain.Entities;

namespace TopStories.Persistence.Configurations.Story
{
    public class TopStoryConfiguration : IEntityTypeConfiguration<TopStory>
    {
        public void Configure(EntityTypeBuilder<TopStory> builder)
        {
            builder.ToTable(nameof(TopStory), "dbo");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Section).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(e => e.SubSection).HasColumnType("nvarchar(50)");
            builder.Property(e => e.Title).HasColumnType("nvarchar(250)").IsRequired();
            builder.Property(e => e.Abstract).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(e => e.Url).HasColumnType("nvarchar(250)").IsRequired();
            builder.Property(e => e.Byline).HasColumnType("nvarchar(250)").IsRequired();
            builder.Property(e => e.CreateTime).HasColumnType("datetime").IsRequired().HasDefaultValueSql("getutcdate()");
            builder.Property(e => e.LastModifiedTime).HasColumnType("datetime").HasDefaultValueSql("getutcdate()");
            builder.HasMany(e => e.MultiMedias).WithOne(t => t.TopStory).HasForeignKey(f => f.StoryId);
        }
    }
}
