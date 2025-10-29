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
    public class GrantPermissionFromRoleCommandHandler(IManagementService _managementService) : IRequestHandler<GrantPermissionFromRoleCommand, DeleteAndUpdateValidatation>
    {
        public async Task<DeleteAndUpdateValidatation> Handle(GrantPermissionFromRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _managementService.GrantPermissionFromRoleAsync(request._permissionId, request._roleId, request._delete);
            return result;
        }
    }
}
