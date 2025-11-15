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
    public class AddUserCommandHandler(IManagementService _managementService) : IRequestHandler<AddUserCommand, AddValidation>
    {
        public async Task<AddValidation> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _managementService.AddUserAsync(request._userAddDto);
            return result;
        }
    }
}

