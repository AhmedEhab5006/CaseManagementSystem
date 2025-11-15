using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.AuditingAndIntegration
{
    public class SyncHistory : BaseEntity
    {
        public string Entity { get; set; } = string.Empty;
        public DateTime LastRunAtUtc { get; set; }
        public string LastRunStatus { get; set; } = string.Empty;
        public string? Notes { get; set; }
    }
}
