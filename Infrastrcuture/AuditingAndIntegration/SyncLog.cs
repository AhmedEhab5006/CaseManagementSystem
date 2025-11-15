using Domain.Entites;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.AuditingAndIntegration
{
    public class SyncLog : BaseEntity
    {

        public string Entity { get; set; } = string.Empty;
        public string EntityKey { get; set; } = string.Empty;
        public DateTime? SentAtUtc { get; set; }
        public int? ResponseCode { get; set; }
        public string? ResponseBody { get; set; }
        public SyncResult Result { get; set; }
    }
}
