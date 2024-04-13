using Domain.Aggregates.Accounts;
using Domain.Aggregates.Accounts.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations.Accounts.Entities;
internal static class UserConfiguration
{
    public static void Configure(this OwnedNavigationBuilder<Account, User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasConversion(id => id.Value, value => new(value));

        builder.Property(u => u.FirstName).IsRequired();
        builder.Property(u => u.FirstName).HasMaxLength(50);

        builder.Property(u => u.LastName).IsRequired();
        builder.Property(u => u.LastName).HasMaxLength(50);

        builder.Property(u => u.DateOfBirth).IsRequired();

        builder.OwnsOne<Address>(u => u.Address, navBuilder => navBuilder.Configure());

        builder.Property(u => u.CreatedAt).IsRequired();

        builder.Property(u => u.UpdatedAt);
    }
}
