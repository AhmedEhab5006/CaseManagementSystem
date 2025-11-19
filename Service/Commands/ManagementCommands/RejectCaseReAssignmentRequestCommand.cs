using Application.Dto_s.ManagementDto_s;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.ManagementCommands
{
    public class RejectCaseReAssignmentRequestCommand : IRequest<DeleteAndUpdateValidatation>
    {
        public Guid RequestId { get; }
        public CaseReAssignmentRejectionDto RejectionDto { get; }

        public RejectCaseReAssignmentRequestCommand(Guid requestId, CaseReAssignmentRejectionDto rejectionDto)
        {
            RequestId = requestId;
            RejectionDto = rejectionDto;
        }
    }
}
