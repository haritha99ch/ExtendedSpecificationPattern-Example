using Domain.Common.Entities;

namespace Domain.Aggregates.Accounts.Entities;
public record Address : Entity
{
    public string? No { get; set; }
    public required string Street { get; set; }
    public required string City { get; set; }

    public static Address Create(string? no, string street, string city) => new()
    {
        No = no,
        Street = street,
        City = city,
        CreatedAt = DateTime.Now
    };

    public Address Update(string? no, string street, string city)
    {
        No = no;
        Street = street;
        City = city;
        UpdatedAt = DateTime.Now;
        return this;
    }
}
