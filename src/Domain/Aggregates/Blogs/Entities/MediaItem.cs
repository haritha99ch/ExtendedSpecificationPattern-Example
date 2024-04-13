using Domain.Aggregates.Blogs.ValueObjects;
using Domain.Common.Entities;

namespace Domain.Aggregates.Blogs.Entities;
public record MediaItem : Entity<MediaItemId>
{
    public required string Url { get; set; }
    public required string Type { get; set; }

    public static MediaItem Create(string url, string type) => new()
    {
        Id = new(Guid.NewGuid()),
        Url = url,
        Type = type,
        CreatedAt = DateTime.Now
    };

    public MediaItem Update(string url, string type)
    {
        Url = url;
        Type = type;
        UpdatedAt = DateTime.Now;
        return this;
    }
}
