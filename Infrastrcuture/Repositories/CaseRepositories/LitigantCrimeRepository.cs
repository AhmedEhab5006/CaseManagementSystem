using Application.Repositories.CaseRepositories;
using Domain.Entites;
using Infrastrcuture.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Application.Commons;
using Application.Dto_s;

namespace Infrastrcuture.Repositories.CaseRepositories
{
    public class LitigantCrimeRepository(
        ApplicationDbContext _context,
        DbSet<LitigantCrime> _dbSet
    ) : GenericRepository<LitigantCrime>(_context, _dbSet), ILitigantCrimeRepository
    {
        
    }
}
