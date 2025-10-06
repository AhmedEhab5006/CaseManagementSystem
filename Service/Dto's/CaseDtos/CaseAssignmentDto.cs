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
    public class CaseAssignmentDto : BaseAddDto
    {
        public Guid CaseId { get; set; }
        [Required(ErrorMessage = "Assigned user Id can't be Empty! | لا يمكن ان يكون معرف المستخدم الموكلة له القضية فارغ")]
        public string assignedUserId { get; set; } = string.Empty;
        [Required(ErrorMessage = "Assigned User Role can't be Empty! | لا يمكن ان يكون صفة المستخدم الموكلة له القضية فارغ")]
        public CaseAssignmentRoles assignedUserRole { get; set; }
        public string assignerId { get; set; } = string.Empty;
        public bool isCurrent { get; set; }
        public string? notes { get; set; } = string.Empty;
    }
}
