using Application.Dto_s.CaseDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto_s.ManagementDto_s
{
    public class UserAddDto : BaseAddDto
    {
        [Required(ErrorMessage = "اسم المستخدم مطلوب")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "البريد الالكتروني مطلوب")]
        [EmailAddress(ErrorMessage = "خطأ في تنسيق البريد الالكتروني")]
        public string Email { get; set; }
        [Required(ErrorMessage = "كلمة المرور مطلوبة")]
        public string Password { get; set; }
        [Required(ErrorMessage = "اسم العرض مطلوب")]
        public string DisplayName { get; set; }
        [Required(ErrorMessage = "الدور مطلوب")]
        public string RoleId { get; set; }
    }
}
