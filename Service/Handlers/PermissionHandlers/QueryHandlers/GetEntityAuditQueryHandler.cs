using Application.Commons;
using Application.Dto_s.Audting;
using Application.Dto_s.ManagementDto_s;
using Application.Interfaces.Audtiting;
using Application.Interfaces.ManagementService;
using Application.Queries.ManagementQueries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.PermissionHandlers.QueryHandlers
{
    public class GetEntityAuditQueryHandler(IAuditTrailService _auditTrailService) : IRequestHandler<GetEntityAuditQuery, PagedResult<AuditGetDto>>
    {
        public async Task<PagedResult<AuditGetDto>> Handle(GetEntityAuditQuery request, CancellationToken cancellationToken)
        {
            var result = await _auditTrailService.GetEntityAudit (request._entityId, request._pageNumber , request._pageSize);
            return result;
        }
    }
}

