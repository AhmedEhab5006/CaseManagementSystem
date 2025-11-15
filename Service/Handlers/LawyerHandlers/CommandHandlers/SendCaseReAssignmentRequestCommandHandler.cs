using Application.Commands.LawyerCommands;
using Application.Dto_s.CaseDtos;
using Application.UseCases.LawyerService;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.LawyerHandlers.CommandHandlers
{
    public class SendCaseReAssignmentRequestCommandHandler(ILawyerService _lawyerService) : IRequestHandler<SendCaseReAssignmentRequestCommand, CaseReAssignmentValidation>
    {
        public async Task<CaseReAssignmentValidation> Handle(SendCaseReAssignmentRequestCommand request, CancellationToken cancellationToken)
        {
            var result = await _lawyerService.SendCaseReAssignmentRequest(request.CaseReAssignmentRequestDto);
            
            return result;
        }
    }
}

