using Domain.Aggregates.Accounts;
using Domain.Aggregates.Accounts.ValueObjects;
using Domain.Aggregates.Blogs.Entities;
using Domain.Aggregates.Blogs.ValueObjects;
using Domain.Common.Aggregates;

namespace Domain.Aggregates.Blogs;
public record Blog : AggregateRoot<BlogId>
{
    public AccountId? AccountId { get; init; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public List<MediaItem> MediaItems { get; init; } = [];
    public List<Post> Posts { get; init; } = [];

    public Account? Account { get; init; }

    public static Blog Create(AccountId accountId, string title, string description) => new()
    {
        Id = new(Guid.NewGuid()),
        AccountId = accountId,
        Title = title,
        Description = description,
        CreatedAt = DateTime.Now
    };

    public Blog Update(string title, string description)
    {
        Title = title;
        Description = description;
        return this;
    }

    public MediaItem AddMediaItem(string url, string type)
    {
        var mediaItem = MediaItem.Create(url, type);
        MediaItems.Add(mediaItem);
        return mediaItem;
    }

    public void RemoveMediaItem(MediaItemId mediaItemId) => MediaItems.RemoveAll(m => m.Id.Equals(mediaItemId));
    public MediaItem UpdateMediaItem(MediaItemId mediaItemId, string url, string type)
        => MediaItems.First(m => m.Id.Equals(mediaItemId)).Update(url, type);

    public Post AddPost(string title, string content)
    {
        var post = Post.Create(title, content);
        Posts.Add(post);
        return post;
    }

    public MediaItem AddMediaItemToPost(PostId postId, string url, string type)
    {
        var post = GetPostById(postId);
        var mediaItem = post.AddMediaItem(url, type);
        return mediaItem;
    }

    public MediaItem UpdateMediaItemInPost(PostId postId, MediaItemId mediaItemId, string url, string type)
    {
        var post = GetPostById(postId);
        var mediaItem = post.UpdateMediaItem(mediaItemId, url, type);
        return mediaItem;
    }

    public void RemoveMediaItemFromPost(PostId postId, MediaItemId mediaItemId)
    {
        var post = GetPostById(postId);
        post.RemoveMediaItem(mediaItemId);
    }

    public Post UpdatePost(PostId postId, string title, string content)
    {
        var post = GetPostById(postId);
        return post.Update(title, content);
    }

    public void RemovePost(PostId postId) => Posts.RemoveAll(p => p.Id.Equals(postId));

    private Post GetPostById(PostId postId) => Posts.First(p => p.Id.Equals(postId));

}
