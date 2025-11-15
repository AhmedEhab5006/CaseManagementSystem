using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto_s.Audting
{
    public class AuditGetDto
    {
        public string ActorName { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public string ActionDate { get; set; } = string.Empty;
    }
}
