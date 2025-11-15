using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto_s.ManagementDto_s
{
    public class CaseReAssignmentRequestGetDto
    {
        public string RequestSender { get; set; } = string.Empty;
        public Guid RequestId { get; set; }
        public string RequestedAssignee { get; set; } = string.Empty;
        public Guid CaseId { get; set; }
        public string CaseNumber { get; set; } = string.Empty;
        public CaseReAssignmentRequestStates Status { get; set; }
    }
}
