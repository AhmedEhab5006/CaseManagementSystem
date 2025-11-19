using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto_s.CaseDtos
{
    public class CaseAttachmentsReadDto
    {
       public Guid CaseId { get; set; }
       public Guid FileId { get; set; }
       public Guid IdInCaseDocuemntTable { get; set; }
       public string VsId { get; set; } = string.Empty;
       public string Description { get; set; } = string.Empty;
       public string UniqueNo { get; set; }
       public string CreatedAt { get; set; } = string.Empty;

    }
}
