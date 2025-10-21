using Application.Commands.CaseCommands.AddCommands;
using Application.UseCases;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.CaseHandlers.CommandHandlers.AddCommandHandlers
{
    public class CaseAddCommandHandler(ICaseService _caseService) : IRequestHandler<CaseAddCommand, CaseAddServiceValidataion>
    {
        public async Task<CaseAddServiceValidataion> Handle(CaseAddCommand request, CancellationToken cancellationToken)
        {
            var done = await _caseService.AddCasePrimaryData(request.Add);
            return done;
        }
    }
}
