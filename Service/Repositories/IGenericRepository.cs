using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IGenericRepository
    {
        public interface IGenericRepository<TEntity> where TEntity : BaseEntity
        {
            Task<IEnumerable<TEntity>> GetAllAsync(bool asNoTracking = false);
            Task<TEntity?> GetByIdAsync(Guid id, bool asNotracking = false);
            Task AddAsync(TEntity entity);
            void Update(TEntity entity);
            void Remove(TEntity entity);
        }
    }
}
