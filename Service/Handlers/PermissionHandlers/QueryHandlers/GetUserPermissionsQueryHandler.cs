using Application.Commons;
using Application.Dto_s.ManagementDto_s;
using Application.Interfaces.ManagementService;
using Application.Queries.ManagementQueries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.PermissionHandlers.QueryHandlers
{
    public class GetUserPermissionsQueryHandler(IManagementService _managementService) : IRequestHandler<GetUserPermissionsQuery, PagedResult<PermissionPrimaryDataReadDto>>
    {
        public async Task<PagedResult<PermissionPrimaryDataReadDto>> Handle(GetUserPermissionsQuery request, CancellationToken cancellationToken)
        {
            var result = await _managementService.GetUserPermissionsAsync(request._userId, request._pageNumber, request._pageSize);
            return result;
        }
    }
}

