using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class CaseDocument : BaseEntity
    {
        public string docType { get; set; }
        public string docCategoryCode { get; set; }
        public int uniqueNo { get; set; }
        public string? VsId { get; set; }
        public string? description { get; set; }
        public Guid CaseId { get; set; }
        public Case? Case { get; set; }
        public Guid? FileAssetId { get; set; }
    }
}
