using Domain.Aggregates.Blogs;
using Domain.Aggregates.Blogs.ValueObjects;
using Shared.Models.Blogs;

namespace Presentation.Specifications.Blogs;
public class BlogPostDetailsListById : Specification<Blog, BlogPostDetails>
{
    public BlogPostDetailsListById(BlogId blogId) : base(b => b.Id.Equals(blogId))
    {
        ProjectTo(b => b.Posts.AsQueryable()
            .Select(p => new BlogPostDetails
            {
                Caption = p.Caption,
                Content = p.Content,
                MediaItems = p.MediaItems.AsQueryable().Select(m => new MediaItemUrl { Url = m.Url }).ToList()
            })
            .ToList());
    }
}
