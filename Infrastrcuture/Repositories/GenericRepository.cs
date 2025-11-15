using Application.Commons;
using Domain.Entites;
using Infrastrcuture.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Application.Repositories.IGenericRepository;

namespace Infrastrcuture.Repositories
{
    public class GenericRepository<TEntity>(ApplicationDbContext _context , DbSet<TEntity> _dbSet) : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        public async Task<PagedResult<TEntity>> GetAllAsync(
            int pageNumber, int pageSize,
             bool asNoTracking = false,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null
        )
        {
            var query = _context.Set<TEntity>()
                .Where(e => !e.isDeleted);

            if (include != null)
                query = include(query);

            int totalRecords = await query.CountAsync();

            if (totalRecords == 0)
            {
                return new PagedResult<TEntity>
                {
                    Data = new List<TEntity>(),
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalRecords = 0
                };
            }

            query = query.OrderBy(e => e.id); // must have stable order

            if (asNoTracking)
                query = query.AsNoTracking();

            var data = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<TEntity>
            {
                Data = data,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = totalRecords
            };
        }

        public async Task<TEntity?> GetByIdAsync(Guid id, bool asNoTracking = true , Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>()
                                        .Where(entity => !entity.isDeleted);
            if (asNoTracking)
                query = query.AsNoTracking();
            
            if (include != null)
                query = include(query);

            return await query.FirstOrDefaultAsync(e => e.id == id);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            // SaveChanges will be called in UnitOfWork
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entitiesList)
        {
            await _context.Set<TEntity>().AddRangeAsync(entitiesList);
            // SaveChanges will be called in UnitOfWork
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            // SaveChanges will be called in UnitOfWork
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            // SaveChanges will be called in UnitOfWork
        }

        public async Task<IEnumerable<TEntity?>> GetByPropertyAsync<TValue>(
    string propertyName,
    TValue value,
    Expression<Func<TEntity, object>>? include = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (include != null)
            {
                query = query.Include(include);
            }

            var property = typeof(TEntity).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            if (property == null)
                throw new InvalidOperationException($"Property '{propertyName}' not found on type '{typeof(TEntity).Name}'.");

            query = query
                .Where(e => !e.isDeleted)
                .Where(e => EF.Property<TValue>(e, propertyName)!.Equals(value));

            return await query.ToListAsync();
        }


        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _context.Set<IEnumerable<TEntity>>().UpdateRange(entities);
        }

        public async Task<IEnumerable<TEntity>> GetManyByPropertiesAsync(
        Dictionary<string, object> filters,
        IQueryable<TEntity>? include = null)
        {
            IQueryable<TEntity> query = include ?? _dbSet;
            query = query.Where(entity => !entity.isDeleted);

            foreach (var filter in filters)
            {
                var propertyInfo = typeof(TEntity).GetProperty(
                    filter.Key,
                    BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance
                );

                if (propertyInfo == null)
                    throw new InvalidOperationException(
                        $"Property '{filter.Key}' not found on type '{typeof(TEntity).Name}'."
                    );

                var parameter = Expression.Parameter(typeof(TEntity), "e");

                var propertyAccess = Expression.Call(
                    typeof(EF),
                    nameof(EF.Property),
                    new[] { propertyInfo.PropertyType },
                    parameter,
                    Expression.Constant(filter.Key)
                );
                var equals = Expression.Equal(propertyAccess, Expression.Constant(filter.Value));

                var lambda = Expression.Lambda<Func<TEntity, bool>>(equals, parameter);
                query = query.Where(lambda);
            }

            return await query.ToListAsync();
        }
    }
}
