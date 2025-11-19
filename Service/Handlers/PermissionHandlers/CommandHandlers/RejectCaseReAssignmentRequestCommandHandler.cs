using Application.Commands.ManagementCommands;
using Application.Interfaces.ManagementService;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.PermissionHandlers.CommandHandlers
{
    public class RejectCaseReAssignmentRequestCommandHandler : IRequestHandler<RejectCaseReAssignmentRequestCommand, DeleteAndUpdateValidatation>
    {
        private readonly IManagementService _managementService;

        public RejectCaseReAssignmentRequestCommandHandler(IManagementService managementService)
        {
            _managementService = managementService;
        }

        public async Task<DeleteAndUpdateValidatation> Handle(
            RejectCaseReAssignmentRequestCommand request,
            CancellationToken cancellationToken)
        {
            var result = await _managementService.RejectCaseReAssignmentRequest(
                request.RequestId,
                request.RejectionDto
            );

            return result;
        }
    }
}
