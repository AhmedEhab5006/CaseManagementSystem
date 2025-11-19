using Application.Dto_s;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.ManagementCommands
{
    public class AcceptCaseReAssignmentRequestCommand : IRequest<DeleteAndUpdateValidatation>
    {
        public Guid RequestId { get; }
        public BaseEditDto BaseEdit { get; }

        public AcceptCaseReAssignmentRequestCommand(Guid requestId, BaseEditDto baseEdit)
        {
            RequestId = requestId;
            BaseEdit = baseEdit;
        }
    }
}

