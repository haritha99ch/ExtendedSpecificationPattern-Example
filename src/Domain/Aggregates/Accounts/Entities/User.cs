using Domain.Aggregates.Accounts.ValueObjects;
using Domain.Common.Entities;

namespace Domain.Aggregates.Accounts.Entities;
public record User : Entity<UserId>
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required DateOnly DateOfBirth { get; set; }
    public Address? Address { get; init; }

    public static User Create(
            string firstName,
            string lastName,
            DateOnly dateOfBirth,
            string? no,
            string street,
            string city
        ) => new()
    {
        Id = new(Guid.NewGuid()),
        FirstName = firstName,
        LastName = lastName,
        DateOfBirth = dateOfBirth,
        Address = Address.Create(no, street, city),
        CreatedAt = DateTime.Now
    };

    public User Update(
            string firstName,
            string lastName,
            DateOnly dateOfBirth,
            string? no,
            string street,
            string city
        )
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        UpdatedAt = DateTime.Now;
        Address!.Update(no, street, city);
        return this;
    }
}
