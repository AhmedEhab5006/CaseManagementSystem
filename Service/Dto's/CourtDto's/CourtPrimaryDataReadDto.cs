using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto_s.CourtDto_s
{
    public class CourtPrimaryDataReadDto
    {
        public Guid Id { get; set; }
        public string NameAr { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string CourtGrade { get; set; } = string.Empty;
        public string IsActive { get; set; } = string.Empty;
    }
}
