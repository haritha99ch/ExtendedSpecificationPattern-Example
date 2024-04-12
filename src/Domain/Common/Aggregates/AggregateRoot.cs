using Domain.Common.Entities;
using Domain.Contracts.Entities;

namespace Domain.Common.Aggregates;
public abstract record AggregateRoot<TEntityId>(TEntityId Id) : Entity<TEntityId>(Id) where TEntityId : EntityId
{
    public List<IDomainEvent> DomainEvents { get; } = [];

    public void RaiseDomainEvent<TDomainEvent>(TDomainEvent domainEvent)
        where TDomainEvent : IDomainEvent => DomainEvents.Add(domainEvent);

    public void RemoveDomainEvent<TDomainEvent>(TDomainEvent domainEvent)
        where TDomainEvent : IDomainEvent => DomainEvents.Remove(domainEvent);

    public void ClearDomainEvents() => DomainEvents.Clear();
}
