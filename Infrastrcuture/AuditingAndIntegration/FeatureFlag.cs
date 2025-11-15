using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.AuditingAndIntegration
{
    public class FeatureFlag : BaseEntity
    {
        public string Key { get; set; } = string.Empty;               
        public bool IsEnabled { get; set; }          
        public string? Description { get; set; }     
      
    }
}
