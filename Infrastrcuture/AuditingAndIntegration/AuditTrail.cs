using Domain.Entites;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.AuditingAndIntegration
{
    public class AuditTrail : BaseEntity
    {
        public DateTime EventAtUtc { get; set; }
        public string ActorUserId { get; set; } = string.Empty;
        public string ActorDisplayName { get; set; } = string.Empty;
        public string EntityName { get; set; } = string.Empty;
        public string EntityKey { get; set; } = string.Empty;
        public AudtingActions Action { get; set; }
        public string ChangedColumnsJson { get; set; } = string.Empty;
        public string OldValuesJson { get; set; } = string.Empty;
        public string NewValuesJson { get; set; } = string.Empty;
        public bool Succeeded { get; set; } 
        public string Error { get; set; } = string.Empty;
    }
}
