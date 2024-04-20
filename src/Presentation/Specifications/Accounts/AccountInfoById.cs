using Domain.Aggregates.Accounts;
using Domain.Aggregates.Accounts.ValueObjects;
using Shared.Models.Accounts;

namespace Presentation.Specifications.Accounts;
public class AccountInfoById : Specification<Account, AccountInfo>
{
    public AccountInfoById(AccountId accountId) : base(a => a.Id.Equals(accountId))
    {
        ProjectTo(a => new()
        {
            Email = a.Email,
            FullName = $"{a.User!.FirstName} {a.User.LastName}"
        });
    }
}
