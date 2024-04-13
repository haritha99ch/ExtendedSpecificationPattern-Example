using Domain.Common.Entities;

namespace Domain.Aggregates.Blogs.ValueObjects;
public record PostId(Guid Value) : EntityId(Value);
