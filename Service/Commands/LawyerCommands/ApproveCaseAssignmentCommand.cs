using Domain.Enums;
using MediatR;

public class ApproveCaseAssignmentCommand : IRequest<DeleteAndUpdateValidatation>
{
    public Guid CaseId { get; set; }
    public string AcceptedBy { get; set; }

    public ApproveCaseAssignmentCommand(Guid caseId, string acceptedBy)
    {
        CaseId = caseId;
        AcceptedBy = acceptedBy;
    }
}
