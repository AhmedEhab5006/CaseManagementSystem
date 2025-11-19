using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto_s.CaseDtos
{
    public class LitigantReadDto
    {
        public Guid id { get; set; }
        public string name { get; set; } = string.Empty;
        public string isOrganisation { get; set; } = string.Empty;
        public string NationalIdNumber { get; set; } = string.Empty;
        public string NationalIdType { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public Guid CaseId { get; set; }

    }
}
