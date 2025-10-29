using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto_s.ManagementDto_s
{
    public class PermissionAssignmentDto
    {
        public Guid permissionId { get; set; }
        public string assignedId { get; set; } = string.Empty;
        public DateTime createdAt { get; set; }
        public string createdBy { get; set; } = string.Empty;
    }
}
