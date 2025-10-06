using Domain.Entites;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto_s.CaseDtos
{
    public class CaseFullDataReadDto
    {

        public Guid CaseId { get; set; }
        public string addtionDate { get; set; } = string.Empty;
        public string RegistererName { get; set; } = string.Empty;
        public string lastModificationDate { get; set; } = string.Empty;
        public string modifier { get; set; } = string.Empty;
        public DateOnly CaseDate { get; set; }
        public string caseNumber { get; set; } = string.Empty;
        public string caseNumberInCourt { get; set; } = string.Empty;
        public string caseNumberInCourtComputer { get; set; } = string.Empty;
        public string caseNumberInClaim { get; set; } = string.Empty;
        public CaseStatus status { get; set; } 
        public bool approved { get; set; } 
        public string governate { get; set; } = string.Empty;
        public string state { get; set; } = string.Empty;
        public string village { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public string CourtName { get; set; } = string.Empty;
        public string CaseType { get; set; } = string.Empty;
        public string caseTitle { get; set; } = string.Empty;
        public string CourtGrade { get; set; } = string.Empty;
    }
}
