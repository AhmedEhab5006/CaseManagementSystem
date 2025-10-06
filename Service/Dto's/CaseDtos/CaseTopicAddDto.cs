using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto_s.CaseDtos
{
    public class CaseTopicAddDto : BaseAddDto
    {
        [Required(ErrorMessage = "Topic Name Can't be Empty | لا يمكن ان يكون اسم موضوع القضية فارغ")]
        public string TopicName { get; set; } = string.Empty;
    }
}
