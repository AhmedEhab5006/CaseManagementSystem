using Application.UseCases;
using Application.UseCases.LawyerService;
using Domain.Enums;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.CaseHandlers.CommandHandlers.DeleteCommandHandlers
{
    public class RevokeReAssignmentRequestCommandHandler : IRequestHandler<RevokeReAssignmentRequestCommand, DeleteAndUpdateValidatation>
    {
        private readonly ILawyerService _lawyerService;

        public RevokeReAssignmentRequestCommandHandler(ILawyerService lawyerService)
        {
            _lawyerService = lawyerService;
        }

        public async Task<DeleteAndUpdateValidatation> Handle(RevokeReAssignmentRequestCommand request, CancellationToken cancellationToken)
        {
            var result = await _lawyerService.RevokeReAssignmentRequests(request.RequestId, request.AssignerId, request.Delete);
            return result;
        }
    }
}
