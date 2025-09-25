using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Judgement : BaseEntity
    {
        public string verdictText { get; set; }
        public DateTime verdictDate { get; set; }
        public bool isApproved { get; set; }
        public Guid hearingId { get; set; }
        public Hearing? hearing { get; set; }
        public ICollection<JudgementOrder>? orders { get; set; }
    }
}
