using Application.Dto_s.CaseDtos;
using Application.Queries.CaseQueries;
using Application.UseCases;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.CaseHandlers.QueryHandlers
{
    public class GetDocTypesForDropDownMenuQueryHandler(ICaseService _caseService) : IRequestHandler<GetDocTypesDropDownMenuQuery, IEnumerable<CaseDropDownMenuGetDto?>>
    {
        public async Task<IEnumerable<CaseDropDownMenuGetDto?>> Handle(GetDocTypesDropDownMenuQuery request, CancellationToken cancellationToken)
        {
            var result = await _caseService.GetDocTypesDropDownMenuAsync();
            return result;
        }
    }
}
