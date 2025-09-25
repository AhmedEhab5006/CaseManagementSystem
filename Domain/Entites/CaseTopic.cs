using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class CaseTopic : BaseEntity
    {
        public string topicName { get; set; }
        public ICollection<Case>? Cases { get; set; }

    }
}
