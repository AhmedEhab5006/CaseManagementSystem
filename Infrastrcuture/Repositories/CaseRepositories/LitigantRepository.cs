using Application.Repositories.CaseRepositories;
using Domain.Entites;
using Infrastrcuture.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.Repositories.CaseRepositories
{
    public class LitigantRepository(ApplicationDbContext _context) : GenericRepository<Litigant>(_context), ILitigantRepository
    {
    }
}
