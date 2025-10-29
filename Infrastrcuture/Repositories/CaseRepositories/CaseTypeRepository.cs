using Application.Repositories.CaseRepositories;
using Domain.Entites;
using Infrastrcuture.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.Repositories.CaseRepositories
{
    public class CaseTypeRepository(ApplicationDbContext _context , DbSet<CaseType> _dbSet) : GenericRepository<CaseType>(_context, _dbSet), ICaseTypeRepository
    {
        public IQueryable<CaseType> GetAll()
        {
            var data =  _context.CasesTypes
                                    .AsNoTracking()
                                    .Where(a=>!a.isDeleted)
                                    .AsQueryable();

            return data;
        }
    }
}
