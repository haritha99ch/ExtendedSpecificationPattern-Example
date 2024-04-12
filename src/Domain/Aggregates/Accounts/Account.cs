using Domain.Aggregates.Accounts.Entities;
using Domain.Aggregates.Accounts.ValueObjects;
using Domain.Common.Aggregates;

namespace Domain.Aggregates.Accounts;
public record Account : AggregateRoot<AccountId>
{
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string PhoneNumber { get; set; }
    public User? User { get; init; }
    public bool Verified { get; set; }

    public static Account Create(
            string email,
            string password,
            string phoneNumber,
            string firstName,
            string lastName,
            DateOnly dateOfBirth,
            string? no,
            string street,
            string city
        ) => new()
    {
        Id = new(Guid.NewGuid()),
        Email = email,
        Password = password,
        PhoneNumber = phoneNumber,
        User = User.Create(firstName, lastName, dateOfBirth, no, street, city),
        CreatedAt = DateTime.Now
    };

    public void UpdateEmail(string email) => Email = email;
    public void UpdatePassword(string password) => Password = password;
    public void UpdatePhoneNumber(string phoneNumber) => PhoneNumber = phoneNumber;
    public void UpdateUser(
            string firstName,
            string lastName,
            DateOnly dateOfBirth,
            string? no,
            string street,
            string city
        ) => User!.Update(firstName, lastName, dateOfBirth, no, street, city);

    public void Verify() => Verified = true;
}
