using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto_s.Audting
{
    public class CaseHistoryReadDto
    {
        public string ActionType { get; set; } = string.Empty;
        public string details { get; set; } = string.Empty;
        public DateTime time { get; set; }
        public string Actor { get; set; }
    }
}
