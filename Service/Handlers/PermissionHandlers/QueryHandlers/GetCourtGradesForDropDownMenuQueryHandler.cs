using Application.Dto_s.CaseDtos;
using Application.Interfaces.ManagementService;
using Application.Queries.ManagementQueries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.PermissionHandlers.QueryHandlers
{
    public class GetCourtGradesForDropDownMenuQueryHandler(IManagementService _managementService) : IRequestHandler<GetCourtGradesForDropDownMenuQuery, IEnumerable<CaseDropDownMenuGetDto>>
    {
        public async Task<IEnumerable<CaseDropDownMenuGetDto>> Handle(GetCourtGradesForDropDownMenuQuery request, CancellationToken cancellationToken)
        {
            var result = await _managementService.GetCourtGradesForDropDownMenuAsync();
            return result;
        }
    }
}

