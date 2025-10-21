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
    public class GetLitigantRolesForDropMenuQueryHandler(ICaseService _caseService) : IRequestHandler<GetLitigantRolesForDropMenuQuery, IEnumerable<CaseDropDownMenuGetDto>>
    {
        public async Task<IEnumerable<CaseDropDownMenuGetDto>> Handle(GetLitigantRolesForDropMenuQuery request, CancellationToken cancellationToken)
        {
            var result = await _caseService.GetLitigantsRoleDropDownMenuAsync();
            return result;
        }
    }
}
