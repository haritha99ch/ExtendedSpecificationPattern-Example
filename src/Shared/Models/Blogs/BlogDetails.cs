using Domain.Models.Blogs;

namespace Shared.Models.Blogs;
public class BlogDetails
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public List<MediaItemUpload> Images { get; set; } = [];
}
