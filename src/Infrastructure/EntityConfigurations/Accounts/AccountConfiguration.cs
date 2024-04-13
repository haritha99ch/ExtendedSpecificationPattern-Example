using Domain.Aggregates.Accounts;
using Domain.Aggregates.Accounts.Entities;
using Infrastructure.EntityConfigurations.Accounts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations.Accounts;
public class AccountConfiguration : IEntityTypeConfiguration<Account>
{

    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).HasConversion(id => id.Value, value => new(value));

        builder.Property(a => a.Email).IsRequired().HasMaxLength(100);
        builder.HasIndex(a => a.Email).IsUnique();

        builder.Property(a => a.Password).IsRequired().HasMaxLength(100);

        builder.Property(a => a.PhoneNumber).IsRequired().HasMaxLength(20);

        builder.OwnsOne<User>(a => a.User, navBuilder => navBuilder.Configure());

        builder.Property(a => a.CreatedAt).IsRequired();

        builder.Property(a => a.UpdatedAt);
    }
}
