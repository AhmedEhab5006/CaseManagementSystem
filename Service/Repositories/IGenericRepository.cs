using Application.Commons;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        
            Task<PagedResult<TEntity>> GetAllAsync(int pageNumber , int pageSize , bool asNoTracking = false 
                , Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null);
            Task<TEntity?> GetByIdAsync(Guid id, bool asNotracking = false 
                , Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null);
            Task AddAsync(TEntity entity);
            Task AddRangeAsync(IEnumerable<TEntity> entitiesList);
            void Update(TEntity entity);
            void Remove(TEntity entity);
            Task<IEnumerable<TEntity?>> GetByPropertyAsync<TValue>(
             string propertyName,
             TValue value,
             params Expression<Func<TEntity, object>>[] includes);
            void UpdateRange(IEnumerable<TEntity> entities);
            Task<IEnumerable<TEntity>> GetManyByPropertiesAsync(Dictionary<string, object> filters, params Expression<Func<TEntity, object>>[] includes);



        }
    }

