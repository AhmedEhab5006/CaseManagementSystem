using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto_s.CaseDtos
{
    public class CaseTypeAddDto : BaseAddDto
    {
        [Required(ErrorMessage = "لا يمكن ان يكون نوع القضية فارغ")]
        public string TypeName { get; set; } = string.Empty;
    }
}
