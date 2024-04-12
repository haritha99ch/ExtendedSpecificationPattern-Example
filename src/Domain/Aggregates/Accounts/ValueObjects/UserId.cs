using Domain.Common.Entities;

namespace Domain.Aggregates.Accounts.ValueObjects;
public record UserId(Guid Value): EntityId(Value);
