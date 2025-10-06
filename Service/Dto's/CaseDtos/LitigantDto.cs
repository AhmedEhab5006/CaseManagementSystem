using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto_s.CaseDtos
{
    public class LitigantDto : BaseAddDto
    {
        public bool isOrganisation { get; set; }
        [Required(ErrorMessage = "لا يمكن ان يكون الاسم باللغة العربية فارغ")]
        public string firstNameAR { get; set; } = string.Empty;
        [Required(ErrorMessage = "لا يمكن ان يكون الاسم باللغة العربية فارغ")]
        public string lastNameAR { get; set; } = string.Empty ;
        public string? firstNameEN { get; set; }
        public string? lastNameEN { get; set; }
        public string? nationalIdNumber { get; set; }
        public string? nationalIdType { get; set; }
        [Required(ErrorMessage = "لا يمكن ان يكون رقم الهاتف فارغ")]
        public string phoneNumber { get; set; } = string.Empty;
        [Required(ErrorMessage = "لا يمكن ان يكون العنوان فارغ")]
        public string address { get; set; } = string.Empty;
        [EmailAddress(ErrorMessage = "بريد الكتروني غير صالح")]
        [Required(ErrorMessage = "لا يمكن ان يكون البريد الالكتروني فارغ")]
        public string email { get; set; } = string.Empty;
        [Required(ErrorMessage = "لا يمكن ان تكون الدولة فارغة")]
        public string country { get; set; } = string.Empty;

    }
}
