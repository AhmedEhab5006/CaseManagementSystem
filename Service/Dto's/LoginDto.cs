using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto_s
{
    public class LoginDto
    {
        [Required(ErrorMessage = "لا يمكن ان يكون اسم المستخدم فارغ")]
        public string username { get; set; }
        [Required(ErrorMessage = "لا يمكن ان تكون كلمة المرور فارغة")]
        public string password { get; set; }
    }
}
