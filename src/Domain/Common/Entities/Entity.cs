namespace Domain.Common.Entities;
public abstract record Entity<TEntityId>(TEntityId Id) : Entity where TEntityId : EntityId;

public abstract record Entity
{
    public required DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; set; }
}