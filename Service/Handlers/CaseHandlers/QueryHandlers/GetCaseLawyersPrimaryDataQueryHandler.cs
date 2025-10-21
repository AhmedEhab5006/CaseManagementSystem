using Application.Commons;
using Application.Dto_s;
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
    public class GetCaseLawyersPrimaryDataQueryHandler(ICaseService _caseService) : IRequestHandler<GetCaseLawyersPrimaryDataQuery, PagedResult<LawyerReadDto>>
    {
        public async Task<PagedResult<LawyerReadDto>> Handle(GetCaseLawyersPrimaryDataQuery request, CancellationToken cancellationToken)
        {
            var result = await _caseService.GetCaseLawyersAsync(request._caseId, request._pageNumber, request._pageSize);
            return result;
        }
    }
}
