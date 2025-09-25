using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class CaseLitigant : BaseEntity
    {
        public Guid caseId { get; set; }
        public Case? Case { get; set; }

        public Guid litigantId { get; set; }
        public Litigant? Litigant { get; set; }

        public Guid roleId { get; set; }
        public CaseLitigantRole? Role { get; set; }

    }
}
