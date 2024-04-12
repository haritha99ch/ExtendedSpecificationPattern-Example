using Domain.Common.Entities;

namespace Domain.Aggregates.Blogs.ValueObjects;
public record BlogId(Guid Value) : EntityId(Value);
