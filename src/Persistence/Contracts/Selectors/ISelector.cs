using Domain.Common.Entities;
using System.Linq.Expressions;

namespace Persistence.Contracts.Selectors;
public interface ISelector<TEntity, TResult> : ISelector where TEntity : Entity
{
    protected internal Expression<Func<TEntity, TResult>> SetProjection();
}

public interface ISelector;
