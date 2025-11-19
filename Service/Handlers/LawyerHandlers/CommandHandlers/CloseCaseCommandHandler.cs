using Application.Commands.LawyerCommands;
using Application.UseCases;
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
    public class CloseCaseCommandHandler : IRequestHandler<CloseCaseCommand, DeleteAndUpdateValidatation>
    {
        private readonly ILawyerService _lawyerService;

        public CloseCaseCommandHandler(ILawyerService lawyerService)
        {
            _lawyerService = lawyerService;
        }

        public async Task<DeleteAndUpdateValidatation> Handle(CloseCaseCommand request, CancellationToken cancellationToken)
        {
            var result = await _lawyerService.CloseCase(request.CaseId, request.CloseData);
            return result;
        }
    }
}
