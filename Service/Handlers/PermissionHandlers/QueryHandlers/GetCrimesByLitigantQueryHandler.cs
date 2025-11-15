using Application.Commons;
using Application.Dto_s.CaseDtos;
using Application.Queries.CaseQueries;
using Application.UseCases;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.CaseHandlers
{
    public class GetCrimesByLitigantQueryHandler : IRequestHandler<GetCrimesByLitigantQuery, PagedResult<CrimeReadDto>>
    {
        private readonly ICaseService _caseService;

        public GetCrimesByLitigantQueryHandler(ICaseService caseService)
        {
            _caseService = caseService;
        }

        public async Task<PagedResult<CrimeReadDto>> Handle(GetCrimesByLitigantQuery request, CancellationToken cancellationToken)
        {
            return await _caseService.GetLitigantCrimesInCase(
                request.LitigantId,
                request.CaseId,
                request.PageNumber,
                request.PageSize
            );
        }
    }
}
