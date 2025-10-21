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
    public class GetCaseTypesForDropMenuQueryHandler(ICaseService _caseService) : IRequestHandler<GetCaseTypesForDropDownMenuQuery, IEnumerable<CaseDropDownMenuGetDto>>
    {
        public async Task<IEnumerable<CaseDropDownMenuGetDto>> Handle(GetCaseTypesForDropDownMenuQuery request, CancellationToken cancellationToken)
        {
            var result = await _caseService.GetCaseTypesForDropDownMenuAsync();
            return result;
        }
    }
}
