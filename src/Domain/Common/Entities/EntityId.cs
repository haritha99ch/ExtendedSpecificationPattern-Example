namespace Domain.Common.Entities;
public record EntityId(Guid Value)
{
    public virtual bool Equals(EntityId? other) => Value.Equals(other!.Value);
    public override int GetHashCode() => Value.GetHashCode();
}
