using Domain.Aggregates.Accounts.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations.Accounts.Entities;
internal static class AddressConfiguration
{
    public static void Configure(this OwnedNavigationBuilder<User, Address> builder)
    {
        builder.Property(a => a.No).HasMaxLength(20);

        builder.Property(a => a.Street).IsRequired();
        builder.Property(a => a.Street).HasMaxLength(100);

        builder.Property(a => a.City).IsRequired();
        builder.Property(a => a.City).HasMaxLength(100);

        builder.Property(a => a.CreatedAt).IsRequired();

        builder.Property(a => a.UpdatedAt);
    }
}
