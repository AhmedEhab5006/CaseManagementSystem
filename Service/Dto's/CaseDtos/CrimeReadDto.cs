using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto_s.CaseDtos
{
    public class CrimeReadDto
    {
        public Guid CrimeId { get; set; }
        public Guid CaseId { get; set; }
        public string CrimeName { get; set; } = string.Empty;
        public string CaseName { get; set; } = string.Empty;
        public string ClaimDate { get; set; } = string.Empty;
    }
}
