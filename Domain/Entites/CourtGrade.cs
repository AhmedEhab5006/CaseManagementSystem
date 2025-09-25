using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class CourtGrade : BaseEntity
    {
        public string nameAR { get; set; }
        public string? nameEN { get; set; }
        public string order { get; set; }
        public bool isActive { get; set; }
        public ICollection<Court>? courts { get; set; }
    }
}
