using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Litigant : BaseEntity
    {
        public bool isOrganisation { get; set; }
        public string? firstNameAR { get; set; }
        public string? lastNameAR { get; set; }
        public string? firstNameEN { get; set; }
        public string? lastNameEN { get; set; }
        public string? nationalIdNumber { get; set; }
        public string? nationalIdType { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string country { get; set; }
        public ICollection<CaseLitigant>? CaseLitigants { get; set; }
    }
}
