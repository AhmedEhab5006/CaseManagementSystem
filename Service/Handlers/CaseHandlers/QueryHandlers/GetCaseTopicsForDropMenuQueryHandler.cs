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
    internal class GetCaseTopicsForDropMenuQueryHandler(ICaseService _caseService) : IRequestHandler<GetCaseTopicsForDropDownMenuQuery, IEnumerable<CaseDropDownMenuGetDto?>>
    {
        public async Task<IEnumerable<CaseDropDownMenuGetDto?>> Handle(GetCaseTopicsForDropDownMenuQuery request, CancellationToken cancellationToken)
        {
            var result = await _caseService.GetCaseTopicsForDropDownMenuAsync();
            return result;
        }
    }
}
