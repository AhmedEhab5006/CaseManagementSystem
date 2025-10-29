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
    public class RolePermissionRepostiory(ApplicationDbContext _context , DbSet<RolePermission> _dbSet) : GenericRepository<RolePermission>(_context, _dbSet), IRolePermissionRepository
    {
    }
}
