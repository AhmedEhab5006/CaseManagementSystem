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
    public class AddPermissionCommandHandler(IManagementService _managementService) : IRequestHandler<AddPermissionCommand, PermissionAddValidation>
    {
        public async Task<PermissionAddValidation> Handle(AddPermissionCommand request, CancellationToken cancellationToken)
        {
            var result = await _managementService.AddPermissionAsync(request._add);
            return result;
        }
    }
}
