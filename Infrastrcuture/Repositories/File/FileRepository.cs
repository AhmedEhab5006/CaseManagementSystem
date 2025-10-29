using Application.Repositories.CourtRepositories;
using Application.Repositories.FileRepoisitories;
using Domain.Entites;
using Domain.Entites.Files;
using Infrastrcuture.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.Repositories.File
{
    public class FileRepository(ApplicationDbContext _context , DbSet<FileEntity> _dbSet) : GenericRepository<FileEntity>(_context, _dbSet), IFileRepository
    {
    }
}
