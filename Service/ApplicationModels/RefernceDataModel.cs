using Domain.Entites;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ApplicationModels
{
    public class RefernceDataModel : BaseEntity
    {
        public ReferenceDataTypes Type { get; set; }
        public string Key { get; set; } = string.Empty;
        public string ValueAr { get; set; } = string.Empty;
        public string? ValueEn { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
    }
}
