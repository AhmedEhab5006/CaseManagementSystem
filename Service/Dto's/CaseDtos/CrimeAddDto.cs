using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto_s.CaseDtos
{
    public class CrimeAddDto : BaseAddDto
    {
        public Guid CrimeId { get; set; }
        public Guid CaseId { get; set; }
        public Guid LitigantId { get; set; }
        public Guid? PenaltyId { get; set; }
    }
}
