using Domain.Aggregates.Blogs.ValueObjects;
using Domain.Common.Entities;

namespace Domain.Aggregates.Blogs.Entities;
public record Post : Entity<PostId>
{
    public required string Caption { get; set; }
    public required string Content { get; set; }
    public List<MediaItem> MediaItems { get; init; } = [];

    public static Post Create(string caption, string content) => new()
    {
        Id = new(Guid.NewGuid()),
        Caption = caption,
        Content = content,
        CreatedAt = DateTime.Now
    };

    public MediaItem AddMediaItem(string url, string type)
    {
        var mediaItem = MediaItem.Create(url, type);
        MediaItems.Add(mediaItem);
        return mediaItem;
    }

    public void RemoveMediaItem(MediaItemId mediaItemId) => MediaItems.RemoveAll(m => m.Id.Equals(mediaItemId));
    public MediaItem UpdateMediaItem(MediaItemId mediaItemId, string url, string type)
        => MediaItems.First(m => m.Id.Equals(mediaItemId)).Update(url, type);

    public Post Update(string caption, string content)
    {
        Caption = caption;
        Content = content;
        UpdatedAt = DateTime.Now;
        return this;
    }
}
