using Domain.Entites;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto_s.CaseDtos
{
    public class CaseAddDto : BaseAddDto
    {
        [Required(ErrorMessage = "Case Date Can't be Empty | لا يمكن ان يكون تاريخ القضية فارغ")]
        public DateOnly caseDate { get; set; }
        [Required(ErrorMessage = "Case Number Can't be Empty | لا يمكن ان يكون رقم القضية فارغ")]
        public string caseNumber { get; set; } = string.Empty;
        [Required(ErrorMessage = "Case Number in Court Can't be Empty | لا يمكن ان يكون رقم القضية في المحكمة فارغ")]
        public string caseNumberInCourt { get; set; } = string.Empty;
        [Required(ErrorMessage = "Case Number in Court Computer Can't be Empty | لا يمكن ان يكون رقم القضية في الحاسب الالي للمحكمة فارغ")]
        public string caseNumberInCourtComputer { get; set; } = string.Empty;
        [Required(ErrorMessage = "Case Number at Claim Can't be Empty | لا يمكن ان يكون رقم القضية في الادعاء فارغ")]
        public string caseNumberInClaim { get; set; } = string.Empty;
        public CaseStatus status { get; set; }
        [Required(ErrorMessage = "Governate Can't be Empty | لا يمكن ان تكون المحافظة فارغة")]
        public string governate { get; set; } = string.Empty;
        [Required(ErrorMessage = "Starte Can't be Empty | لا يمكن ان تكون الولاية فارغة")]
        public string state { get; set; } = string.Empty;
        [Required(ErrorMessage = "Village Can't be Empty | لا يمكن ان تكون القرية فارغة")] 
        public string village { get; set; } = string.Empty;
        [Required(ErrorMessage = "Description Can't be Empty | لا يمكن ان يكون الوصف فارغ")] 
        public string description { get; set; } = string.Empty;
        [Required(ErrorMessage = "CourtId Can't be Empty | لا يمكن ان يكون رقم المحكمة فارغ")]
        public Guid courtId { get; set; }
        [Required(ErrorMessage = "Case Type Can't be Empty | لا يمكن ان يكون رقم نوع القضية فارغ")]
        public Guid caseTypeId { get; set; }
        [Required(ErrorMessage = "Case Topic Can't be Empty | لا يمكن ان يكون موضوع القضية فارغ")]
        public Guid caseTopicId { get; set; }
      
    }
}
