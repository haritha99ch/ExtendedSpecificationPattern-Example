using Domain.Models.Blogs;

namespace Shared.Models.Blogs;
public class BlogPostDetails
{
    public required string Caption { get; set; }
    public required string Content { get; set; }
    public List<MediaItemUpload> MediaItemUploads { get; set; } = [];
}
