using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class LegalClaim : BaseEntity
    {
        public double amount { get; set; }
        public string currency { get; set; }
        public string claimType { get; set; }
        public string? legalBasis { get; set; }
        public string? notes { get; set; }
        public Guid CaseId { get; set; }
        public Case? Case { get; set; }

    }
}
