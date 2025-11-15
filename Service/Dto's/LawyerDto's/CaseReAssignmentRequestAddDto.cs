using Application.CustomValidatations;
using Application.Dto_s.CaseDtos;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto_s.LawyerDto_s
{
    public class CaseReAssignmentRequestAddDto : BaseAddDto
    {
        [Required(ErrorMessage = "لا يمكن ان يكون معرف المحامي فارغ")]
        [NotEqualFilter("AssigneeId", ErrorMessage = "لا يمكن اعادة اسناد الدعوى لنفس المحامي المسنده له من قبل")]
        public string AssignerId { get; set; } = string.Empty;
        [Required(ErrorMessage = "لا يمكن ان يكون معرف المحامي المراد تعيين الدعوى له فارغ")]
        [NotEqualFilter("AssignerId", ErrorMessage = "لا يمكن اعادة اسناد الدعوى لنفس المحامي المسنده له من قبل")]
        public string AssigneeId { get; set; } = string.Empty;
        [Required(ErrorMessage = "لا يمكن ان يكون معرف الدعوى فارغ")]
        public Guid CaseId { get; set; }
        public CaseReAssignmentRequestStates RequestStatus { get; set; }
    }
}
