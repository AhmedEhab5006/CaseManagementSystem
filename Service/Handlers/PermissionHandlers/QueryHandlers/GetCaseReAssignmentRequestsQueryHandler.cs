using Application.Commons;
using Application.Dto_s.ManagementDto_s;
using Application.Interfaces.ManagementService;
using Application.Queries.ManagementQueries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.PermissionHandlers.QueryHandlers
{
    public class GetCaseReAssignmentRequestsQueryHandler(IManagementService _managementService) : IRequestHandler<GetCaseReAssignmentRequestsQuery, PagedResult<CaseReAssignmentRequestGetDto>>
    {
        public async Task<PagedResult<CaseReAssignmentRequestGetDto>> Handle(GetCaseReAssignmentRequestsQuery request, CancellationToken cancellationToken)
        {
            var result = await _managementService.GetCaseReAssignmentRequests(request._pageNumber, request._pageSize);
            return result;
        }
    }
}

