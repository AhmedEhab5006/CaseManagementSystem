using Application.Dto_s.CaseDtos;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.CaseCommands.AddCommands
{
    public class CaseAssignToLawyerCommand : IRequest<CaseAssignmentServiceValidatation>
    {
        public IEnumerable<CaseAssignmentDto> caseAssignmentDtos { get;}

        public CaseAssignToLawyerCommand(IEnumerable<CaseAssignmentDto> caseAssignments)
        {
            caseAssignmentDtos = caseAssignments;
        }
    }
}
