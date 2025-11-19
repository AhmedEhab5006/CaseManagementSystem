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
    public class GetClosedCasesQueryHandler(ICaseService _caseService)
         : IRequestHandler<GetClosedCasesQuery, PagedResult<CaseReadDto>>
    {
        public async Task<PagedResult<CaseReadDto>> Handle(GetClosedCasesQuery request, CancellationToken cancellationToken)
        {
            return await _caseService.GetClosedCases(request.PageNumber, request.PageSize);
        }
    }
}
