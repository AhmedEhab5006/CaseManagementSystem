using Application.Commons;
using Application.Dto_s.LawyerDto_s;
using MediatR;

public class GetMyReAssignmentRequestsQuery : IRequest<PagedResult<CaseReAssignmentRequestsReadDto>>
{
    public string AssignerId { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public GetMyReAssignmentRequestsQuery(string assignerId, int pageNumber, int pageSize)
    {
        AssignerId = assignerId;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}
