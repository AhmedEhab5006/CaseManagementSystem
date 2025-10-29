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
    public class AssignPermissionToUserCommandHandler(IManagementService _managementService) : IRequestHandler<AssignUserToPermissionCommand, AssignValdiation>
    {
        public async Task<AssignValdiation> Handle(AssignUserToPermissionCommand request, CancellationToken cancellationToken)
        {
            var result = await _managementService.AssignUserToPermissionAsync(request._assign);
            return result;
        }
    }
}
