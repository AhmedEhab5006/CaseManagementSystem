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
    public class GetCaseLitigantFullDataQueryHandler(ICaseService _caseService) : IRequestHandler<GetCaseLitigantFullDataQuery, LitigantDto>
    {
        public async Task<LitigantDto> Handle(GetCaseLitigantFullDataQuery request, CancellationToken cancellationToken)
        {
            var result = await _caseService.GetCaseLitigantFullDataAsync(request._litigantId);
            return result;
        }
    }
}
