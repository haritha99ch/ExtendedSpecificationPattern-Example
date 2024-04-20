using Domain.Aggregates.Blogs;
using Domain.Aggregates.Blogs.ValueObjects;
using Shared.Models.Blogs;

namespace Presentation.Specifications.Blogs;
public class BlogDetailsById : Specification<Blog, BlogDetails>
{
    public BlogDetailsById(BlogId blogId) : base(b => b.Id.Equals(blogId))
    {
        ProjectTo(b => new()
        {
            Title = b.Title,
            Description = b.Description,
            MediaItem = new() { Url = b.MediaItem!.Url }
        });
    }
}
