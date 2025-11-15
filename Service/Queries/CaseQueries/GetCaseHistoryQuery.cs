using Application.Commons;
using Application.Dto_s.Audting;
using MediatR;

public class GetCaseHistoryQuery : IRequest<PagedResult<CaseHistoryReadDto>>
{
    public Guid CaseId { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public GetCaseHistoryQuery(Guid caseId, int pageNumber = 1, int pageSize = 10)
    {
        CaseId = caseId;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}
