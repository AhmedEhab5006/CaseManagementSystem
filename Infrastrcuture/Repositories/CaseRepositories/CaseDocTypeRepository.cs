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
    public class CaseDocTypeRepository(ApplicationDbContext _context, DbSet<DocType> _dbSet) : GenericRepository<DocType>(_context, _dbSet), ICaseDocTypeRepository
    {
        public IQueryable<DocType> GetAll()
        {
            var data = _context.DocumentsTypes
                                     .AsNoTracking()
                                     .Where(a => !a.isDeleted)
                                     .AsQueryable();

            return data;
        }
    }
}
