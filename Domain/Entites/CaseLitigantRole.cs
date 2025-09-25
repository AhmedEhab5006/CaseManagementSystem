using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class CaseLitigantRole : BaseEntity
    {
        public string roleName { get; set; }
        public ICollection<CaseLitigant>? CaseLitigants { get; set; }
    }
}
