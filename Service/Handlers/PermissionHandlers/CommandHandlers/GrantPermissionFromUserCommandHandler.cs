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
    public class GrantPermissionFromUserCommandHandler(IManagementService _managementService) : IRequestHandler<GrantPermissionFromUserCommand, DeleteAndUpdateValidatation>
    {
        public async Task<DeleteAndUpdateValidatation> Handle(GrantPermissionFromUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _managementService.GrantPermissionFromUserAsync(request._permissionId, request._userId, request._delete);
            return result;
        }
    }
}
