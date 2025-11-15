using Domain.Entites;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.AuditingAndIntegration
{
    public class SystemSetting : BaseEntity
    {
        public string Key { get; set; } = string.Empty;               
        public string Value { get; set; } = string.Empty;             
        public string? Description { get; set; }      
        public SystemSettingScope Scope { get; set; }            
    }
}
