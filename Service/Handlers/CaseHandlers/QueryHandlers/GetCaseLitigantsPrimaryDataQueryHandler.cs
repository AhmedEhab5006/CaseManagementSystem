using Application.Commons;
using Application.Dto_s.CaseDtos;
using Application.Queries.CaseQueries;
using Application.UseCases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.CaseHandlers.QueryHandlers
{
    public class GetCaseLitigantsPrimaryDataQueryHandler(ICaseService _caseService) : IRequestHandler<GetCaseLitigantsPrimaryDataQuery, PagedResult<LitigantReadDto>>
    {
        public async Task<PagedResult<LitigantReadDto>> Handle(GetCaseLitigantsPrimaryDataQuery request, CancellationToken cancellationToken)
        {
            var result = await _caseService.GetCaseLitigantsAsync(request._pageNumber, request._pageSize, request._caseId);
            return result;
        }
    }
}
