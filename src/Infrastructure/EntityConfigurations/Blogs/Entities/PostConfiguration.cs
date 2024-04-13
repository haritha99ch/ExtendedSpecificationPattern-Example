using Domain.Aggregates.Blogs;
using Domain.Aggregates.Blogs.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations.Blogs.Entities;
internal static class PostConfiguration
{
    public static void Configure(this OwnedNavigationBuilder<Blog, Post> builder)
    {
        builder.ToTable($"{nameof(Post)}s");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasConversion(id => id.Value, value => new(value));

        builder.Property(p => p.Caption).IsRequired();

        builder.Property(p => p.Content).IsRequired();

        builder.OwnsMany(p => p.MediaItems, navBuilder => navBuilder.Configure())
            .Navigation(p => p.MediaItems)
            .AutoInclude(false);
    }
}
