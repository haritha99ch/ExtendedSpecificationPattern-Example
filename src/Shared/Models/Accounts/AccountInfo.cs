using Shared.Contracts.Selectors;

namespace Shared.Models.Accounts;
public class AccountInfo : ISelector
{
    public required string Email { get; set; }
    public required string FullName { get; set; }
}
