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
    public class GetAllQueryHandler(ICaseService _caseService) : IRequestHandler<GetAllQuery, PagedResult<CaseReadDto>>
    {
        public async Task<PagedResult<CaseReadDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var result = await _caseService.GetAllCasesMainDataAsync(request._pageNumber , request._pageSize);
            return result;
        }
    }
}
