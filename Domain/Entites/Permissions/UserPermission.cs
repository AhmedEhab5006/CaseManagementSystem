using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Entites.Permissions

{
    public class UserPermission : BaseEntity
    {
        public string UserId { get; set; } = string.Empty;
        public Guid PermissionId { get; set; }

        public Permission? Permission { get; set; }
    }
}
