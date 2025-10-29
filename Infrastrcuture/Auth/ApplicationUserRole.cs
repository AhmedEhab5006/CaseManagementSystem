using Domain.Entites.Permissions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.Auth
{
    public class ApplicationUserRole : IdentityRole
    {
        public ICollection<RolePermission>? RolePermissions { get; set; }

    }
}
