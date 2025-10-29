using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto_s.AccountDto_s
{
    public class AccountEditDto : BaseEditDto
    {
        [Required(ErrorMessage = "لا يمكن ان يكون الاسم فارغ")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "لا يمكن ان تكون كلمة المرور فارغة")]
        public string Password { get; set; } = string.Empty;
        [Required(ErrorMessage = "لا يمكن ان يكون البريد الالكتروني فارغ")]
        [EmailAddress(ErrorMessage = "بريد الكتروني غير سليم")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "لا يمكن ان تكون الصورة فارغة")]
        public string Image { get; set; } = string.Empty;
        [Required(ErrorMessage = "لا يمكن ان يكون اسم المستخدم فارغ")]
        public string username { get; set; } = string.Empty;
    }
}
