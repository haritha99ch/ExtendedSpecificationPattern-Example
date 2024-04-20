using Shared.Contracts.Selectors;

namespace Shared.Models.Blogs;
public class BlogPostDetails : ISelector
{
    public required string Caption { get; set; }
    public required string Content { get; set; }
    public List<MediaItemUrl> MediaItems { get; set; } = [];
}
