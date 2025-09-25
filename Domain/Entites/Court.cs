using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Court : BaseEntity
    {
        public string nameAR { get; set; }
        public string? nameEN { get; set; }
        public string? city { get; set; }
        public bool isActive { get; set; }
        public Guid courtGradeId { get; set; }
        public CourtGrade? courtGrade { get; set; }
        public ICollection<Case>? Cases { get; set; }
    }
}
