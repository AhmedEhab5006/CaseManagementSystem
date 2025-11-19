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
    public class ReAssignmentRequestAcceptCommandHandler : IRequestHandler<AcceptCaseReAssignmentRequestCommand, DeleteAndUpdateValidatation>
    {
        private readonly IManagementService _managementService;

        public ReAssignmentRequestAcceptCommandHandler(IManagementService managementService)
        {
            _managementService = managementService;
        }

        public async Task<DeleteAndUpdateValidatation> Handle(
            AcceptCaseReAssignmentRequestCommand request,
            CancellationToken cancellationToken)
        {
            var result = await _managementService.AcceptCaseReAssignmentRequest(
                request.RequestId,
                request.BaseEdit
            );

            return result;
        }
    }
}
