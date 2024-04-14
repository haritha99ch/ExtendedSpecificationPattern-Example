﻿using Domain.Common.Aggregates;
using Domain.Common.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Persistence.Common.Specifications;
using Persistence.Contracts.Repositories;
using Persistence.Helpers.Specifications;
using Shared.Contracts.Selectors;
using System.Linq.Expressions;

namespace Persistence.Repositories;
internal class Repository<TEntity, TEntityId> : IRepository<TEntity, TEntityId> where TEntity : AggregateRoot<TEntityId>
    where TEntityId : EntityId
{
    private readonly ApplicationDbContext _context;
    private DbSet<TEntity> DbSet => _context.Set<TEntity>();
    private readonly Func<TEntityId, Expression<Func<TEntity, bool>>> _predicateById = id => e => e.Id.Equals(id);
    private bool _tracking;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var result = await DbSet.AddAsync(entity, cancellationToken);
        await SaveChangesAsync(cancellationToken);
        return result.Entity;
    }

    public async Task<TEntity?> GetByIdAsync(TEntityId entityId, CancellationToken cancellationToken = default)
        => await (_tracking ? DbSet.AsTracking() : DbSet.AsNoTracking())
            .FirstOrDefaultAsync(_predicateById(entityId), cancellationToken);

    public async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        => await DbSet.AsNoTracking().ToListAsync(cancellationToken);

    public async Task<bool> ExistByIdAsync(TEntityId entityId, CancellationToken cancellationToken = default)
        => await DbSet.AsNoTracking()
            .AnyAsync(_predicateById(entityId), cancellationToken);

    public async Task<int> CountAsync(CancellationToken cancellationToken = default)
        => await DbSet.AsNoTracking().CountAsync(cancellationToken);

    public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var entry = DbSet.Update(entity);
        await SaveChangesAsync(cancellationToken);
        ClearChangeTracker();
        return entry.Entity;
    }

    public async Task<bool> DeleteByIdAsync(TEntityId entityId, CancellationToken cancellationToken = default)
    {
        var deleted =
            await DbSet.Where(_predicateById(entityId))
                .ExecuteDeleteAsync(cancellationToken)
            > 0;
        await SaveChangesAsync(cancellationToken);
        ClearChangeTracker();
        return deleted;
    }
    public async Task<TEntity?> GetOneAsync<TSpecification>(
            TSpecification specification,
            CancellationToken cancellationToken = default
        ) where TSpecification : Specification<TEntity>
        => await (_tracking ? DbSet.AsTracking() : DbSet.AsNoTracking())
            .AddSpecification(specification)
            .FirstOrDefaultAsync(cancellationToken);


    public async Task<List<TEntity>> GetManyAsync<TSpecification>(
            TSpecification specification,
            CancellationToken cancellationToken = default
        ) where TSpecification : Specification<TEntity>
        => await DbSet.AsNoTracking()
            .AddSpecification(specification)
            .ToListAsync(cancellationToken);

    public async Task<int> CountAsync<TSpecification>(
            TSpecification specification,
            CancellationToken cancellationToken = default
        ) where TSpecification : Specification<TEntity>
        => await DbSet.AsNoTracking()
            .AddSpecification(specification)
            .CountAsync(cancellationToken);

    public async Task<bool> ExistsAsync<TSpecification>(
            TSpecification specification,
            CancellationToken cancellationToken = default
        ) where TSpecification : Specification<TEntity>
        => await DbSet.AsNoTracking()
            .AddSpecification(specification)
            .AnyAsync(cancellationToken);

    public async Task<bool> DeleteAsync<TSpecification>(
            TSpecification specification,
            CancellationToken cancellationToken = default
        ) where TSpecification : Specification<TEntity>
    {
        var deleted = await DbSet.AddSpecification(specification)
                .ExecuteDeleteAsync(cancellationToken)
            > 0;
        await SaveChangesAsync(cancellationToken);
        ClearChangeTracker();
        return deleted;
    }

    public async Task<TResult?> GetOneAsync<TSpecification, TResult>(
            TSpecification specification,
            CancellationToken cancellationToken = default
        ) where TSpecification : Specification<TEntity, TResult>
        where TResult : ISelector
        => await DbSet.AsNoTracking().AddSpecification(specification).FirstOrDefaultAsync(cancellationToken);


    public async Task<List<TResult>> GetManyAsync<TSpecification, TResult>(
            TSpecification specification,
            CancellationToken cancellationToken = default
        ) where TSpecification : Specification<TEntity, TResult>
        where TResult : ISelector
        => await DbSet.AsNoTracking().AddSpecification(specification).ToListAsync(cancellationToken);


    public IRepository<TEntity, TEntityId> AsTracking()
    {
        _tracking = true;
        return this;
    }

    private async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

    private void ClearChangeTracker()
    {
        _context.ChangeTracker.Clear();
        _tracking = false;
    }
}
