using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class CaseType : BaseEntity
    {
        public string typeName { get; set; }
        public ICollection<Case>? Cases { get; set; }
    }
}
