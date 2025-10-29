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
    public class CaseTopicRepository(ApplicationDbContext _context , DbSet<CaseTopic> _dbSet) : GenericRepository<CaseTopic>(_context, _dbSet), ICaseTopicRepository
    {
        public IQueryable<CaseTopic> GetAll()
        {
            var data = _context.CasesTopics
                                    .AsNoTracking()
                                    .Where(a => !a.isDeleted)
                                    .AsQueryable();

            return data;
        }
    }
}
