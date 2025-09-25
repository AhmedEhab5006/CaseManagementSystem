using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class TaskItem : BaseEntity
    {
        public string title { get; set; }
        public string? assignedTo { get; set; }
        public DateTime? dueTo { get; set; }
        public string status { get; set; }
        public Guid CaseId { get; set; }
        public Case? Case { get; set; }
    }
}
