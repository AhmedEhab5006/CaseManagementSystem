using Application.Commons;
using Application.Dto_s.LawyerDto_s;
using Application.Queries.CaseQueries;
using Application.UseCases.LawyerService;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.CaseHandlers.QueryHandlers
{
    public class GetMyReAssignmentRequestsQueryHandler(ILawyerService _reAssignmentService)
        : IRequestHandler<GetMyReAssignmentRequestsQuery, PagedResult<CaseReAssignmentRequestsReadDto>>
    {
        public async Task<PagedResult<CaseReAssignmentRequestsReadDto>> Handle(
            GetMyReAssignmentRequestsQuery request,
            CancellationToken cancellationToken)
        {
            var result = await _reAssignmentService.GetMyReAssignmentRequests(
                request.AssignerId,
                request.PageNumber,
                request.PageSize
            );

            return result;
        }
    }
}
