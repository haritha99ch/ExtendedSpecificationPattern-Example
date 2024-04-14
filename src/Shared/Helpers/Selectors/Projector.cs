using Domain.Common.Entities;
using Shared.Contracts.Selectors;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Shared.Helpers.Selectors;
public static class Projector
{
    public static Expression<Func<TEntity, TResult>> GetProjection<TEntity, TResult>()
        where TEntity : Entity
        where TResult : ISelector<TEntity, TResult>
        => ((TResult)RuntimeHelpers.GetUninitializedObject(typeof(TResult))).SetProjection();
}
