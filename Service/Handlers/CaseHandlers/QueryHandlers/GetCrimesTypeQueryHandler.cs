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
    public class GetCrimesTypeQueryHandler(ICaseService _caseService) : IRequestHandler<GetCrimesForDropMenuQuery, IEnumerable<CaseDropDownMenuGetDto>>
    {
        public async Task<IEnumerable<CaseDropDownMenuGetDto>> Handle(GetCrimesForDropMenuQuery request, CancellationToken cancellationToken)
        {
            var data = await _caseService.GetAvailableCrimesAsync();
            return data;
        }
    }
}
