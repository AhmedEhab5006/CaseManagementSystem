using Application.Commands.CaseCommands.AddCommands;
using Application.UseCases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.CaseHandlers.CommandHandlers.AddCommandHandlers
{
    public class CaseAddLitigantRoleCommandHandler(ICaseService _caseService) : IRequestHandler<CaseAddLitigantRoleCommad, bool>
    {
        public async Task<bool> Handle(CaseAddLitigantRoleCommad request, CancellationToken cancellationToken)
        {
            var result = await _caseService.AddCaseLitigantRoleAsync(request._caseLitigantRoleDto);
            return result;
        }
    }
}
