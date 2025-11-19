using Application.UseCases;
using Application.UseCases.LawyerService;
using Domain.Enums;
using MediatR;

namespace Application.Handlers.CaseHandlers.CommandHandlers.UpdateCommandHandlers
{
    public class CaseApproveFirstAssignmentCommandHandler(ILawyerService _lawyerService)
        : IRequestHandler<ApproveCaseAssignmentCommand, DeleteAndUpdateValidatation>
    {
        public async Task<DeleteAndUpdateValidatation> Handle(
            ApproveCaseAssignmentCommand request,
            CancellationToken cancellationToken)
        {
            var result = await _lawyerService.AcceptCaseAssignment(
                request.CaseId,
                request.AcceptedBy
            );

            return result;
        }
    }
}
