using Application.Dto_s;
using Application.Interfaces.ManagementService;
using Application.Queries.ManagementQueries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.PermissionHandlers.QueryHandlers
{
    public class GetAllRolesQueryHandler(IManagementService _managementService) : IRequestHandler<GetAllRolesQuery, IEnumerable<RoleReadDto>>
    {
        public async Task<IEnumerable<RoleReadDto>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var result = await _managementService.GetRolesForSlideMenuAsync();
            return result;
        }
    }
}

