using Application.Repositories;
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
using static Application.Repositories.IGenericRepository;

namespace Infrastrcuture.Repositories.ManagementRepos
{
    public class UserPermissionRepository(ApplicationDbContext _context , DbSet<UserPermission> _dbSet) : GenericRepository<UserPermission>(_context, _dbSet), IUserPermissionRepository
    {
    }
}
