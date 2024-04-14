namespace Shared.Models.Accounts;
public class AccountCreateInfo
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required DateOnly DateOfBirth { get; set; }
    public required string AddressNo { get; set; }
    public required string AddressStreet { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}
