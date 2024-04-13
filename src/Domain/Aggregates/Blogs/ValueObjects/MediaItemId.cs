using Domain.Common.Entities;

namespace Domain.Aggregates.Blogs.ValueObjects;
public record MediaItemId(Guid Value) : EntityId(Value);
