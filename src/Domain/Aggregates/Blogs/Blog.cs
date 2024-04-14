using Domain.Aggregates.Accounts;
using Domain.Aggregates.Accounts.ValueObjects;
using Domain.Aggregates.Blogs.Entities;
using Domain.Aggregates.Blogs.ValueObjects;
using Domain.Common.Aggregates;
using Domain.Models.Blogs;

namespace Domain.Aggregates.Blogs;
public record Blog : AggregateRoot<BlogId>
{
    public AccountId? AccountId { get; init; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public MediaItem? MediaItem { get; init; }
    public List<Post> Posts { get; init; } = [];

    public Account? Account { get; init; }

    public static Blog Create(AccountId accountId, string title, string description, MediaItemUpload mediaItemUpload)
        => new()
        {
            Id = new(Guid.NewGuid()),
            AccountId = accountId,
            Title = title,
            Description = description,
            MediaItem = MediaItem.Create(mediaItemUpload.Url, mediaItemUpload.Type),
            CreatedAt = DateTime.Now
        };

    public Blog Update(string title, string description)
    {
        Title = title;
        Description = description;
        return this;
    }

    public MediaItem UpdateMediaItem(MediaItemUpload mediaItemUpload)
        => MediaItem!.Update(mediaItemUpload.Url, mediaItemUpload.Type);

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

    public MediaItem UpdateMediaItemInPost(PostId postId, MediaItemId mediaItemId, MediaItemUpload mediaItemUpload)
    {
        var post = GetPostById(postId);
        var mediaItem = post.UpdateMediaItem(mediaItemId, mediaItemUpload.Url, mediaItemUpload.Type);
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
