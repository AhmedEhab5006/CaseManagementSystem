using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class DocType : BaseEntity
    {
        public string Type { get; set; } = string.Empty;
        public string CategoryCode { get; set; } = string.Empty;
    }
}
