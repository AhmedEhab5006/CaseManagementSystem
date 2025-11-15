using Domain.Entites;
using Infrastrcuture.AuditingAndIntegration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.HelperEntites
{
    public class ContractTemplate : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public Guid TypeId { get; set; }
        public string Content { get; set; } = string.Empty;
    
    }
}
