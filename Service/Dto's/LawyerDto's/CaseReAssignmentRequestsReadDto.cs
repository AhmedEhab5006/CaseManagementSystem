using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto_s.LawyerDto_s
{
    public class CaseReAssignmentRequestsReadDto
    {
        public Guid RequestId { get; set; }
        public Guid CaseId { get; set; }
        public string CaseNumber { get; set; }
        public string CaseTitle { get; set; }
        public string NewLawyerName { get; set; }
        public DateTime RequestDate { get; set; }
        public CaseReAssignmentRequestStates State { get; set; }
        public string RejectionReason { get; set; } 
    }
}
