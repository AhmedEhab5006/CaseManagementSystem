using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites.Permissions

{
    public class RolePermission : BaseEntity
    {
        public string RoleId { get; set; } = string.Empty;
        public Guid PermissionId { get; set; }

        public Permission? Permission { get; set; }
    }
}
