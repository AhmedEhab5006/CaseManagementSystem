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
    public class GetCaseFullDataQueryHandler(ICaseService _caseService) : IRequestHandler<GetFullDataQuery, CaseFullDataReadDto>
    {
        public async Task<CaseFullDataReadDto> Handle(GetFullDataQuery request, CancellationToken cancellationToken)
        {
            var result = await _caseService.GetCaseAllDataAsync(request._caseId);
            return result;
        }
    }
}
