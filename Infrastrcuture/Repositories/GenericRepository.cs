using Application.Commons;
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
        public async Task<PagedResult<TEntity>> GetAllAsync(int pageNumber, int pageSize 
            , bool asNoTracking = true , Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>()
                .Where(entity => !entity.isDeleted);

            if (asNoTracking)
                query = query.AsNoTracking();

            if (include != null)
                query = include(query);

            int totalRecords = await query.CountAsync();

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
            IQueryable<TEntity> query = _context.Set<TEntity>();
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
