using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Application.Dto_s.Audting;
using Application.Commons;

namespace Application.Interfaces.Audtiting
{
    public interface IAuditTrailService
    {
        Task RecordAuditAsync(IEnumerable<EntityEntry> entries, CancellationToken cancellationToken = default);
        Task<PagedResult<AuditGetDto>> GetEntityAudit (Guid entityId , int pageNumber, int pageSize);
    }
}
