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
    public class AssignRoleToPermissionCommandHandler(IManagementService _managementService) : IRequestHandler<AssignRoleToPermissionCommand, AssignValdiation>
    {
        public async Task<AssignValdiation> Handle(AssignRoleToPermissionCommand request, CancellationToken cancellationToken)
        {
            var result = await _managementService.AssignRoleToPermissionAsync(request._assign);
            return result;
        }
    }
}
