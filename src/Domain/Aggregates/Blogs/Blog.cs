using Domain.Aggregates.Accounts;
using Domain.Aggregates.Accounts.ValueObjects;
using Domain.Aggregates.Blogs.Entities;
using Domain.Aggregates.Blogs.ValueObjects;
using Domain.Common.Aggregates;

namespace Domain.Aggregates.Blogs;
public record Blog : AggregateRoot<BlogId>
{
    public AccountId? AccountId { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public List<MediaItem> MediaItems { get; set; } = [];

    public Account? Account { get; init; }
}
