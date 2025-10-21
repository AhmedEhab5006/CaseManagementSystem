using Application.Commands.CaseCommands.AddCommands;
using Application.Dto_s.CaseDtos;
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
    public class CaseAssignmentHandler(ICaseService _caseService) : IRequestHandler<CaseAssignToLawyerCommand ,  CaseAssignmentServiceValidatation>
    { 
       public async Task<CaseAssignmentServiceValidatation> Handle(CaseAssignToLawyerCommand request, CancellationToken cancellationToken)
        {
            var result = await _caseService.AssignCaseToLawyerAsync(request.caseAssignmentDtos);

            return result;
        }
    }
}
