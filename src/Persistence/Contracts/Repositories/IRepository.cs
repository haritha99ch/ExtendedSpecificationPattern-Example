using Domain.Common.Aggregates;
using Domain.Common.Entities;
using Persistence.Common.Specifications;
using Persistence.Contracts.Selectors;

namespace Persistence.Contracts.Repositories;
public interface IRepository<TEntity, in TEntityId> where TEntity : AggregateRoot<TEntityId> where TEntityId : EntityId
{
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<TEntity?> GetByIdAsync(TEntityId entityId, CancellationToken cancellationToken = default);
    Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<bool> ExistByIdAsync(TEntityId entityId, CancellationToken cancellationToken = default);
    Task<int> CountAsync(CancellationToken cancellationToken = default);
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<bool> DeleteByIdAsync(TEntityId entityId, CancellationToken cancellationToken = default);


    Task<TEntity?> GetOneAsync<TSpecification>(
            TSpecification specification,
            CancellationToken cancellationToken = default
        ) where TSpecification : Specification<TEntity>;

    Task<List<TEntity>> GetManyAsync<TSpecification>(
            TSpecification specification,
            CancellationToken cancellationToken = default
        ) where TSpecification : Specification<TEntity>;

    Task<int> CountAsync<TSpecification>(TSpecification specification, CancellationToken cancellationToken = default)
        where TSpecification : Specification<TEntity>;

    Task<bool> ExistsAsync<TSpecification>(TSpecification specification, CancellationToken cancellationToken = default)
        where TSpecification : Specification<TEntity>;

    Task<bool> DeleteAsync<TSpecification>(TSpecification specification, CancellationToken cancellationToken = default)
        where TSpecification : Specification<TEntity>;


    Task<TResult?> GetOneAsync<TSpecification, TResult>(
            TSpecification specification,
            CancellationToken cancellationToken = default
        ) where TSpecification : Specification<TEntity, TResult>
        where TResult : ISelector;

    Task<List<TResult>> GetManyAsync<TSpecification, TResult>(
            TSpecification specification,
            CancellationToken cancellationToken = default
        ) where TSpecification : Specification<TEntity, TResult>
        where TResult : ISelector;

    IRepository<TEntity, TEntityId> AsTracking();
}
