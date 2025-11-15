using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto_s.CourtDto_s
{
    public class CourtFullDataReadDto
    {
        public Guid CourtId { get; set; }
        public string addtionDate { get; set; } = string.Empty;
        public string RegistererName { get; set; } = string.Empty;
        public string lastModificationDate { get; set; } = string.Empty;
        public string modifier { get; set; } = string.Empty;
        public string NameAr { get; set; } = string.Empty;
        public string NameEn { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string IsActive { get; set; } = string.Empty;
        public string CourtGradeName { get; set; } = string.Empty;
    }
}
