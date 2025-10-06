using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto_s.CaseDtos
{
    public class CaseReadDto
    {
        public Guid CaseId { get; set; }
        public string CaseNumber { get; set; } = string.Empty;
        public DateOnly CaseDate { get; set; }
        public string CaseTitle { get; set; } = string.Empty;
        public string CaseType { get; set; } = string.Empty;
        public string CourtName { get; set; } = string.Empty;
        public string CourtGrade { get; set; } = string.Empty;
        public CaseStatus Status { get; set; }

    }
}
