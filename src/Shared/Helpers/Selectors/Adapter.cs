using Domain.Common.Entities;
using Shared.Contracts.Selectors;

namespace Shared.Helpers.Selectors;
public static class Adapter
{
    public static TResult Adapt<TEntity, TResult>(this TEntity entity)
        where TEntity : Entity
        where TResult : ISelector<TEntity, TResult>
    {
        var projector = Projector.GetProjection<TEntity, TResult>().Compile();
        return projector(entity);
    }
}
