using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto_s.ManagementDto_s
{
    public class CaseReAssignmentRejectionDto : BaseEditDto
    {
        [Required(ErrorMessage = "لا يمكن ان يكون سبب الرفض فارغ")]
        public string RejectionReason { get; set; } = string.Empty;
    }
}
