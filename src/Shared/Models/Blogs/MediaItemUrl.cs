using Shared.Contracts.Selectors;

namespace Shared.Models.Blogs;
public class MediaItemUrl : ISelector
{
    public required string Url { get; set; }
}
