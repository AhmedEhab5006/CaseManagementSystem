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
    public class CourtAddCommandHandler(IManagementService _managementService) : IRequestHandler<CourtAddCommand, AddValidation>
    {
        public async Task<AddValidation> Handle(CourtAddCommand request, CancellationToken cancellationToken)
        {
            var result = await _managementService.CourtAddAsync(request._courtAddDto);
            return result;
        }
    }
}

