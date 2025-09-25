using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class JudgementOrder : BaseEntity
    {
        public string orderType { get; set; }
        public bool isInternal { get; set; }
        public string? approvalStatus { get; set; }
        public Guid judgementId { get; set; }
        public Judgement? judgement { get; set; }
    }
}
