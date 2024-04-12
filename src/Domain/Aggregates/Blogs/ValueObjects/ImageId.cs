using Domain.Common.Entities;

namespace Domain.Aggregates.Blogs.ValueObjects;
public record ImageId(Guid Value) : EntityId(Value);
