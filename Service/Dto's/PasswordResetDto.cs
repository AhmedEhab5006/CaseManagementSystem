using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto_s
{
    public class PasswordResetDto
    {
        [Required(ErrorMessage = "لا يمكن ان تكون كلمة المرور فارغة")]
        [Compare("newPasswordConifrmed", ErrorMessage = "كلمات المرور غير متطابقة")]
        public string newPassword { get; set; }
        [Required(ErrorMessage = "لا يمكن ان تكون كلمة المرور فارغة")]
        [Compare("newPassword" , ErrorMessage = "كلمات المرور غير متطابقة")]
        public string newPasswordConifrmed { get; set; }
    }
}
