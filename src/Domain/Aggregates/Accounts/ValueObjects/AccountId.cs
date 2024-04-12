using Domain.Common.Entities;

namespace Domain.Aggregates.Accounts.ValueObjects;
public record AccountId(Guid Value): EntityId(Value);
