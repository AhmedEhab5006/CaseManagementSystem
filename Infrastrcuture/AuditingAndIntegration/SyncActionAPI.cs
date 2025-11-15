using Domain.Entites;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.AuditingAndIntegration
{
    public class SyncActionAPI : BaseEntity
    {
        public string Entity { get; set; } = string.Empty;
        public string EntityKey { get; set; } = string.Empty;
        public AudtingActions Operation { get; set; }
        public DateTime RequestedAtUtc { get; set; }
        public string RequestedBy { get; set; } = string.Empty;
        public string? Status { get; set; }
        public string? Notes { get; set; }
    }
}
