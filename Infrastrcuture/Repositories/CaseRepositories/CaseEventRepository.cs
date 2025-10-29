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
    public class CaseEventRepository(ApplicationDbContext _context , DbSet<CaseEvent> _dbSet) : GenericRepository<CaseEvent>(_context, _dbSet), ICaseEventRepository
    {
    }
}
