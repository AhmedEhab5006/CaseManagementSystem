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
    public class CaseAddCaseLitigantCommandHandler(ICaseService _caseService) : IRequestHandler<CaseAddCaseLitigantCommand, CaseLitigantAddVaildatation>
    {
        public async Task<CaseLitigantAddVaildatation> Handle(CaseAddCaseLitigantCommand request, CancellationToken cancellationToken)
        {
            var result = await _caseService.AddCaseLitigantsRangeAsync(request._caseLtitgantDto);
            return result;
            
        }
    }
}
