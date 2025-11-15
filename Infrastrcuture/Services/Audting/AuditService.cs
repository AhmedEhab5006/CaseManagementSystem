using Application.Commons;
using Application.Dto_s.Audting;
using Application.Interfaces.Audtiting;
using Application.Repositories;
using Application.UseCases.Auth;
using Domain.Entites;
using Domain.Enums;
using Infrastrcuture.AuditingAndIntegration;
using Infrastrcuture.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastrcuture.Services.Audting
{
    public class AuditService(ApplicationDbContext _context , IAuthService _authService) : IAuditTrailService
    {
       

        public async Task<PagedResult<AuditGetDto>> GetEntityAudit(Guid entityId , int pageNumber , int pageSize)
        {
            var query = _context.AuditTrails
                      .Where(a => a.EntityKey == entityId.ToString())
                      .OrderByDescending(a => a.EventAtUtc);

            var totalCount = await query.CountAsync();

            var audit = await query
                                .Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

            var auditDtos = audit.Select(entity => new AuditGetDto
            {
                ActionDate = entity.createdAt.ToString("yyyy-MM-dd"),
                ActorName = entity.ActorDisplayName,
                Action = entity.Action == AudtingActions.Delete ? "عملية حذف"
                        : entity.Action == AudtingActions.Insert ? "عملية اضافة"
                        : entity.Action == AudtingActions.Update ? "عملية تعديل"
                        : "غير محدد"
            }).ToList();

            return new PagedResult<AuditGetDto>
            {
                Data = auditDtos,
                TotalRecords = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

        }

        public async Task RecordAuditAsync(IEnumerable<EntityEntry> entries, CancellationToken cancellationToken = default)
        {
            var auditEntries = new List<AuditTrail>();

            foreach (var entry in entries)
            {
                if (entry.Entity is BaseEntity entity)
                {
                    var audit = new AuditTrail
                    {
                        id = Guid.NewGuid(),
                        EntityName = entry.Entity.GetType().Name,
                        EntityKey = entity.id.ToString(),
                        EventAtUtc = DateTime.UtcNow,
                        Action = entry.State switch
                        {
                            EntityState.Added => AudtingActions.Insert,
                            EntityState.Modified => AudtingActions.Update,
                            EntityState.Deleted => AudtingActions.Delete,
                            _ => AudtingActions.Update
                        },
                        ChangedColumnsJson = JsonSerializer.Serialize(entry.Properties.Where(p => p.IsModified).Select(p => p.Metadata.Name)),
                        OldValuesJson = JsonSerializer.Serialize(entry.Properties.Where(p => p.OriginalValue != null).ToDictionary(p => p.Metadata.Name, p => p.OriginalValue)),
                        NewValuesJson = JsonSerializer.Serialize(entry.Properties.Where(p => p.CurrentValue != null).ToDictionary(p => p.Metadata.Name, p => p.CurrentValue)),
                        Succeeded = true,
                        createdAt = DateTime.UtcNow,
                        createdBy = "System",
                        ActorDisplayName = entity.createdBy,
                        ActorUserId = _authService.GetLoggedId()
                    };

                    auditEntries.Add(audit);
                }
            }

            if (auditEntries.Any())
            {
                await _context.AuditTrails.AddRangeAsync(auditEntries, cancellationToken);
            }
        }
    }
}
