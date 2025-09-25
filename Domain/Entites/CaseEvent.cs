using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class CaseEvent : BaseEntity
    {
        public string eventType { get; set; }
        public string? details { get; set; }
        public Guid CaseId { get; set; }
        public Case? Case { get; set; }

    }
}
