using Domain.Entites;
using Infrastrcuture.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Repositories.IGenericRepository;

namespace Infrastrcuture.Repositories
{
    public class GenericRepository<TEntity>(ApplicationDbContext _context) : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        public async Task<IEnumerable<TEntity>> GetAllAsync(bool asNoTracking = true)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>()
                .Where(entity => !entity.isDeleted);
            if (asNoTracking)
                query = query.AsNoTracking();
            return await query.ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(Guid id, bool asNoTracking = true)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (asNoTracking)
                query = query.AsNoTracking();
            return await query.SingleOrDefaultAsync(entity => !entity.isDeleted && entity.id == id); //used singleOrDefaultAsync to ensure only one entity is returned and as id is unique
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
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
    }
}
