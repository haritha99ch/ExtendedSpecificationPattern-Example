using Domain.Models.Blogs;

namespace Shared.Models.Blogs;
public class BlogCreateInfo
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required MediaItemUpload MediaItemUpload { get; set; }
}
