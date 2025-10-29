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
    public class GetAllPermissionsQueryHandler(IManagementService _managementService) : IRequestHandler<GetAllPermissionsQuery, PagedResult<PermissionPrimaryDataReadDto>>
    {
        public async Task<PagedResult<PermissionPrimaryDataReadDto>> Handle(GetAllPermissionsQuery request, CancellationToken cancellationToken)
        {
            var result = await _managementService.GetAllPermissionsAsync(request._pageNumber, request._pageSize);
            return result;
        }
    }
}
