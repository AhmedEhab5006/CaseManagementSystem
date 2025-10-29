using Application.Repositories.FileRepoisitories;
using Application.Repositories.ManagementRepos;
using Domain.Entites;
using Domain.Entites.Files;
using Domain.Entites.Permissions;
using Infrastrcuture.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.Repositories.ManagementRepos
{
    public class PermissionRepostiory(ApplicationDbContext _context , DbSet<Permission> _dbSet) : GenericRepository<Permission>(_context, _dbSet), IPermissionRepository
    {
    }
}
