using Shared.Contracts.Selectors;

namespace Shared.Models.Blogs;
public class BlogDetails : ISelector
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required MediaItemUrl MediaItem { get; set; }
}
