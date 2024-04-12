using Domain.Aggregates.Blogs.ValueObjects;
using Domain.Common.Entities;

namespace Domain.Aggregates.Blogs.Entities;
public record MediaItem : Entity<ImageId>
{
    public required string Url { get; set; }
    public required string Type { get; set; }
}
