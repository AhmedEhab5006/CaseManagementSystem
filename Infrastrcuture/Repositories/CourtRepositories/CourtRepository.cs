using Application.Repositories.CaseRepositories;
using Application.Repositories.CourtRepositories;
using Domain.Entites;
using Infrastrcuture.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.Repositories.CourtRepositories
{
    public class CourtRepository(ApplicationDbContext _context) : GenericRepository<Court>(_context), ICourtRepository
    {
        public IQueryable<Court> GetAll()
        {
            var data = _context.Courts
                        .AsNoTracking()
                        .Where(a => !a.isDeleted)
                        .AsQueryable();

            return data;
        }
    }
}
