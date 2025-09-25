using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Hearing : BaseEntity
    {
        public int number { get; set; }
        public DateTime currentHearingDate { get; set; }
        public DateTime? nextHearingDate { get; set; }
        public enum scheduledBy { lawyer , researcher }
        public string? location { get; set; }
        public string? notes { get; set; }
        public Guid CaseId { get; set; }
        public Case? Case { get; set; }
        public ICollection<Judgement>? judgements { get; set; }

    }
}
