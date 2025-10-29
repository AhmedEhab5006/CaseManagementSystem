using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto_s.ManagementDto_s
{
    public class RolePermissionAssignmentReadDto
    {
        public string rolename { get; set; } = string.Empty;
        public DateOnly AssignmentDate { get; set; }
        public string Assigner { get; set; } = string.Empty;

    }
}
