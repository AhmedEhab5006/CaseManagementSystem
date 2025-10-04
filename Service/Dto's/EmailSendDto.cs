using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto_s
{
    public class EmailSendDto
    {
        [Required(ErrorMessage = "لا يمكن ان يكون البريد الالكتروني فارغ")]
        [EmailAddress(ErrorMessage = "بريد الكتروني غير صالح")]
        public string email { get; set; }
    }
}
