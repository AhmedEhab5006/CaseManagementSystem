using Application.Dto_s.CaseDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto_s.ManagementDto_s
{
    public class PermissionDto : BaseAddDto
    {
        [Required(ErrorMessage = "لا يمكن ان يكون اسم الصلاحية فارغ")]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

    }
}
