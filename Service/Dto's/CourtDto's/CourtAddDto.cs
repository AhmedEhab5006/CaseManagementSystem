using Application.Dto_s.CaseDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto_s.CourtDto_s
{
    public class CourtAddDto : BaseAddDto
    {
        [Required(ErrorMessage = "لا يمكن ان يكون اسم المحكمة باللغة العربية فارغ")]
        public string NameAr { get; set; } = string.Empty;
        public string? NameEn { get; set; } = string.Empty;
        [Required(ErrorMessage = "لا يمكن ان تكون المدينة فارغة")]
        public string City { get; set; } = string.Empty;
        [Required(ErrorMessage = "لا يمكن ان يكون معرف درجة المحكمة فارغ")]
        public Guid CourtGradeId { get; set; }
    }
}
