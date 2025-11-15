using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class LitigantCrime : BaseEntity
    {
        public Case? Case { get; set; }
        public Guid CaseId { get; set; }
        public Litigant? Litigant { get; set; }
        public Guid LitigantId { get; set; }
        public Guid CrimeId { get; set; }
        public Guid? PenaltyId { get; set; }
    }
}
