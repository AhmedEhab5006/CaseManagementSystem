using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class CaseReAssignmentRequest : BaseEntity
    {
        public string AssignerId { get; set; } = string.Empty;
        public string AssigneeId { get; set; } = string.Empty;
        public Guid CaseId { get; set; }
        public CaseReAssignmentRequestStates RequestStatus { get; set; }

    }
}
