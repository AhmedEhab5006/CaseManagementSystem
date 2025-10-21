using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto_s.CaseDtos
{
    public class CaseDocumentAddDto : BaseAddDto
    {
        [Required(ErrorMessage = "لا يمكن ان يكون رقم الدعوى فارغ")]
        public Guid CaseId { get; set; }
        [Required(ErrorMessage = "لا يمكن ان يكون رقم المستند فارغ")]
        public Guid DocumentId { get; set; }
        [Required(ErrorMessage = "لا يمكن ان يكون نوع المستند فارغ")]
        public Guid DocTypeId { get; set; }
        [Required(ErrorMessage = "لا يمكن ان يكون رقم المستند الفريد فارغ")]
        public string uniqueNo { get; set; } = string.Empty;
        [Required(ErrorMessage = "لا يمكن ان يكون اصدار المستند فارغ")]
        public string? VsId { get; set; }
        public string? description { get; set; }
    }
}
