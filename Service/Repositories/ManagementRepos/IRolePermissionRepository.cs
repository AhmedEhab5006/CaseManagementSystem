using Domain.Entites.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Repositories.IGenericRepository;

namespace Application.Repositories.ManagementRepos
{
    public interface IRolePermissionRepository : IGenericRepository<RolePermission>
    {
    }
}
