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
    public class DeleteUserCommandHandler(IManagementService _managementService) : IRequestHandler<DeleteUserCommand, DeleteAndUpdateValidatation>
    {
        public async Task<DeleteAndUpdateValidatation> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _managementService.DeleteUserAsync(request._userId, request._delete);
            return result;
        }
    }
}

