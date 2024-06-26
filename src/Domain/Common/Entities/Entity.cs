﻿namespace Domain.Common.Entities;
public abstract record Entity<TEntityId> : Entity where TEntityId : EntityId
{
    public required TEntityId Id { get; init; }
}

public abstract record Entity
{
    public required DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; set; }
}