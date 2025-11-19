using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto_s.LawyerDto_s
{
    public class CloseCaseDto : BaseEditDto
    {
        public string breif { get; set; } = string.Empty;
        public string lawyerId { get; set; } = string.Empty;

    }
}
