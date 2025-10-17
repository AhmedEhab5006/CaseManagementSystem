using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto_s.CaseDtos
{
    public class LawyerFullDataReadDto
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int numberOfPendingCases { get; set; }
        public int numberOfCurrentCases { get; set; }
        public int numberOfClosedCases { get; set; }
        public string creationDate { get; set; } = string.Empty;
        public string creator { get; set; } = string.Empty;
        public string modificationDate { get; set; } = string.Empty;
        public string modifier { get; set; } = string.Empty;
        public string phoneNumber { get; set; } = string.Empty;
    }
}
