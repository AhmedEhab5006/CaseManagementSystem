using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.AuditingAndIntegration
{
    public class MessageSequence : BaseEntity
    {

            public string ServiceCode { get; set; } = string.Empty;
            public long CurrentValue { get; set; }
        

    }
}
