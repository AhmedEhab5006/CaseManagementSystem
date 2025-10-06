using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto_s.CaseDtos
{
    public class CaseLitigantRoleDto : BaseAddDto
    {
        [Required(ErrorMessage = "لا يمكن ترك اسم الدور فارغ")]
        public string RoleName { get; set; } = string.Empty;
    }
}
