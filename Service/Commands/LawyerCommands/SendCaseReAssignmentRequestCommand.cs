using Application.Dto_s.CaseDtos;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.LawyerCommands
{
    public class SendCaseReAssignmentRequestCommand : IRequest<CaseReAssignmentValidation>
    {
        public CaseReAssignmentRequestDto CaseReAssignmentRequestDto { get; }

        public SendCaseReAssignmentRequestCommand(CaseReAssignmentRequestDto caseReAssignmentRequestDto)
        {
            CaseReAssignmentRequestDto = caseReAssignmentRequestDto;
        }
    }
}

