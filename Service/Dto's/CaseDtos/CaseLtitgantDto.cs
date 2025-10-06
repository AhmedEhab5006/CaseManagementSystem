using Domain.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto_s.CaseDtos
{
    public class CaseLtitgantDto : BaseAddDto
    {

        [Required(ErrorMessage = "لا يمكن ان يكون القضية فارغة")]
        public Guid caseId { get; set; }

        [Required(ErrorMessage = "لا يمكن ان يكون طرف القضية فارغ")]
        public Guid litigantId { get; set; }
        [Required(ErrorMessage = "لا يمكن ان يكون صفة طرف القضية فارغة")]
        public Guid roleId { get; set; }

    }
}
