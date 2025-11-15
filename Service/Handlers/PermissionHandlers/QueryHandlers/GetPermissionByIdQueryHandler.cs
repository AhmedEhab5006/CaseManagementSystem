using Application.Dto_s.ManagementDto_s;
using Application.Interfaces.ManagementService;
using Application.Queries.ManagementQueries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.PermissionHandlers.QueryHandlers
{
    public class GetPermissionByIdQueryHandler(IManagementService _managementService) : IRequestHandler<GetPermissionByIdQuery, PermissionPrimaryDataReadDto?>
    {
        public async Task<PermissionPrimaryDataReadDto?> Handle(GetPermissionByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _managementService.GetPermissionByIdAsync(request._permissionId);
            return result;
        }
    }
}

