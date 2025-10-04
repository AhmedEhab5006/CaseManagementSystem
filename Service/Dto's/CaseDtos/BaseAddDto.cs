using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto_s.CaseDtos
{
    public class BaseAddDto
    {
        [Required(ErrorMessage = "Creator Can't be Empty | لا يمكن ان يكون المنشئ فارغ")]
        public string createdBy { get; set; } = string.Empty;
       
    }
}
