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
    public class GetCourtsForDropMenuQueryHandler(ICaseService _caseService) : IRequestHandler<GetCourtsForDropMenuQuery, IEnumerable<CaseDropDownMenuGetDto>>
    {
        public async Task<IEnumerable<CaseDropDownMenuGetDto>> Handle(GetCourtsForDropMenuQuery request, CancellationToken cancellationToken)
        {
            var result = await _caseService.GetCourtsForDropDownMenuAsync();
            return result;
        }
    }
}
