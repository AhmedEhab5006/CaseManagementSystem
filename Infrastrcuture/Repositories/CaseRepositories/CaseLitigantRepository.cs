using Application.Commons;
using Application.Repositories.CaseRepositories;
using Domain.Entites;
using Infrastrcuture.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.Repositories.CaseRepositories
{
    public class CaseLitigantRepository(ApplicationDbContext _context , DbSet<CaseLitigant> _dbSet) : GenericRepository<CaseLitigant>(_context , _dbSet), ICaseLitigantRepository
    {
        public async Task<PagedResult<CaseLitigant>> GetCaseLitigantsAsync(Guid caseId, int pageNumber , int pageSize )
        {
            var query = _context.CasesLitigants
                .AsNoTracking()
                .Where(a => a.caseId == caseId)
                .Include(a => a.Litigant)
                .Include(a => a.Role)
                .AsQueryable();

            var totalCount = await query.CountAsync();

            var data = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<CaseLitigant>
            {
                Data = data,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = totalCount
            };
            
        }
    }
}
