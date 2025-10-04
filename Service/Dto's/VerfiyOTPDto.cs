using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto_s
{
    public class VerfiyOTPDto
    {
        [Required(ErrorMessage = "لا يمكن ان تكون كلمة المرور المؤقتة فارغة")]
        public string Otp { get; set; }
    }
}
