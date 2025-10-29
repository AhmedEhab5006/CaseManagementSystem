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
    public class DeletePermissionCommandHandler(IManagementService _managementService) : IRequestHandler<DeletePermissionCommand, DeleteAndUpdateValidatation>
    {
        public async Task<DeleteAndUpdateValidatation> Handle(DeletePermissionCommand request, CancellationToken cancellationToken)
        {
            var result = await _managementService.DeletePermissionAsync(request._PermissionId, request._Delete);
            return result;
        }
    }
}
