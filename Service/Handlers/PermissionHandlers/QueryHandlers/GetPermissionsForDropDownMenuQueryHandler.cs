using Application.Dto_s.CaseDtos;
using Application.Interfaces.ManagementService;
using Application.Queries.ManagementQueries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.PermissionHandlers.QueryHandlers
{
    public class GetPermissionsForDropDownMenuQueryHandler(IManagementService _managementService) : IRequestHandler<GetPermissionsForDropDownMenuQuery, IEnumerable<CaseDropDownMenuGetDto>>
    {
        public async Task<IEnumerable<CaseDropDownMenuGetDto>> Handle(GetPermissionsForDropDownMenuQuery request, CancellationToken cancellationToken)
        {
            var result = await _managementService.GetPermissionsForDropDownMenuAsync();
            return result;
        }
    }
}

