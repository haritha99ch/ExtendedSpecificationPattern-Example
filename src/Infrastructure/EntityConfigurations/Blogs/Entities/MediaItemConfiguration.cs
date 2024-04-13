using Domain.Aggregates.Blogs.Entities;
using Domain.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations.Blogs.Entities;
internal static class MediaItemConfiguration
{
    public static void Configure<TEntity>(this OwnedNavigationBuilder<TEntity, MediaItem> builder)
        where TEntity : Entity
    {
        builder.ToTable($"{typeof(TEntity).Name}{nameof(MediaItem)}s");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id).HasConversion(id => id.Value, value => new(value));

        builder.Property(m => m.Url).IsRequired();

        builder.Property(m => m.Type).IsRequired();
    }
}
