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
    public class UpdatePermissionCommandHandler(IManagementService _managementService) : IRequestHandler<UpdatePermissionCommand, DeleteAndUpdateValidatation>
    {
        public async Task<DeleteAndUpdateValidatation> Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
        {
            var result = await _managementService.UpdatePermissionAsync(request._permissionId, request._updateDto);
            return result;
        }
    }
}
