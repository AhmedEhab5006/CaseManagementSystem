using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto_s.CaseDtos
{
    public class CaseReAssignmentRequestDto : BaseAddDto
    {
        [Required(ErrorMessage = "Case Id can't be Empty! | لا يمكن ان يكون معرف القضية فارغ")]
        public Guid CaseId { get; set; }
        
        [Required(ErrorMessage = "Assignee Id can't be Empty! | لا يمكن ان يكون معرف المستخدم الموكلة له القضية فارغ")]
        public string AssigneeId { get; set; } = string.Empty;
        
        public string AssignerId { get; set; } = string.Empty;
    }
}


