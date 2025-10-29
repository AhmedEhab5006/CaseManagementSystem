using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto_s.Commons
{
    public class DeleteDto
    {
        public string DeletionReason { get; set; } = string.Empty;
        public DateTime DeletedAt { get; set; }
        public string DeletedBy { get; set; } = string.Empty;
    }
}
