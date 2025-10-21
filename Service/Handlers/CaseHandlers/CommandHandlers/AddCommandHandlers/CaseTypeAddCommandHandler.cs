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
    public class CaseTypeAddCommandHandler(ICaseService _caseService) : IRequestHandler<CaseAddTypeCommand, bool>
    {
        public async Task<bool> Handle(CaseAddTypeCommand request, CancellationToken cancellationToken)
        {
            var result = await _caseService.AddCaseTypeAsync(request._typeDto);

            return result;
        }
    }
}
