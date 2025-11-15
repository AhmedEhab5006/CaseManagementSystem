using Application.Commons;
using Application.Dto_s.Audting;
using Application.UseCases;
using MediatR;

public class GetCaseHistoryQueryHandler : IRequestHandler<GetCaseHistoryQuery, PagedResult<CaseHistoryReadDto>>
{
    private readonly ICaseService _caseService;

    public GetCaseHistoryQueryHandler(ICaseService caseService)
    {
        _caseService = caseService;
    }

    public async Task<PagedResult<CaseHistoryReadDto>> Handle(GetCaseHistoryQuery request, CancellationToken cancellationToken)
    {
        var result = await _caseService.GetCaseHistory(request.CaseId, request.PageNumber, request.PageSize);
        return result;
    }
}
