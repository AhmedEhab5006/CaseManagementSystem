using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class CaseAssignment : BaseEntity
    {
        public Guid CaseId { get; set; }
        public Case? Case { get; set; }
        public string assignedUserId { get; set; }
        public enum assignedUserRole {lawyer , resarcher }
        public string assignerId { get; set; }
        public bool isCurrent { get; set; }
        public string? notes { get; set; }
    }
}
