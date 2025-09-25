using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Case : BaseEntity
    {
        public DateOnly caseDate { get; set; }
        public string caseNumber { get; set; }
        public string caseNumberInCourt { get; set; }
        public string caseNumberInCourtComputer { get; set; }
        public string caseNumberInClaim { get; set; }
        public enum status { Registered , UnderStudy , Pleading , Judged , Closed}
        public bool approved { get; set; }
        public string governate { get; set; }
        public string state { get; set; }
        public string village { get; set; }
        public string description { get; set; }
        public Guid courtId { get; set; }
        public Court? court { get; set; }
        public Guid caseTypeId { get; set; }
        public CaseType? caseType { get; set; }
        public Guid caseTopicId { get; set; }
        public CaseTopic? caseTopic { get; set; }
        public Guid courtGradeId { get; set; }
        public CourtGrade? CourtGrade { get; set; }
        public ICollection<CaseDocument>? caseDocuments { get; set; }
        public ICollection<CaseAssignment>? assignments { get; set; }
        public ICollection<LegalClaim>? claims { get; set; }
        public ICollection<CaseEvent>? events { get; set; }
        public ICollection<TaskItem>? taskItems { get; set; }
        public ICollection<Hearing>? hearings {  get; set; }
        public ICollection<CaseLitigant>? CaseLitigants { get; set; }
       
    }
}
