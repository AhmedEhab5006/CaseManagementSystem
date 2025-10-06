using Application.Repositories.CaseRepositories;
using Application.Repositories.CourtRepositories;
using Domain.Entites;
using Infrastrcuture.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.Repositories.CourtRepositories
{
    public class CourtGradeRepository(ApplicationDbContext _context) : GenericRepository<CourtGrade>(_context), ICourtGradeRepository
    {
    }
}
