using Domain.Entites;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.AuditingAndIntegration
{
    public class ExternalMessage : BaseEntity
    {
        public ExternalMessageDirection Direction { get; set; }       
        public string Entity { get; set; } = string.Empty;           
        public string EntityKey { get; set; } = string.Empty;        
        public string PayloadJson { get; set; } = string.Empty;      
    }
}
