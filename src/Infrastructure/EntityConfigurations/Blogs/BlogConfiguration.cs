using Domain.Aggregates.Blogs;
using Infrastructure.EntityConfigurations.Blogs.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations.Blogs;
public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{

    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).HasConversion(id => id.Value, value => new(value));

        builder.Property(b => b.AccountId)
            .HasConversion(id => id != null ? id.Value : default, value => new(value));
        builder.HasOne(b => b.Account).WithMany().HasForeignKey(b => b.AccountId);

        builder.Property(b => b.Title).IsRequired();

        builder.Property(b => b.Description).IsRequired();


        builder.OwnsMany(b => b.MediaItems, navBuilder => navBuilder.Configure())
            .Navigation(b => b.MediaItems)
            .AutoInclude(false);

        builder.OwnsMany(b => b.Posts, navBuilder => navBuilder.Configure())
            .Navigation(b => b.Posts)
            .AutoInclude(false);
    }
}
