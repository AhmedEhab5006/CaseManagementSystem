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
    public class CaseDocumentRepository(ApplicationDbContext _context) : GenericRepository<CaseDocument>(_context), ICaseDocumentRepository
    {
    }
}
