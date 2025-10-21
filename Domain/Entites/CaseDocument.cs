using Domain.Entites.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class CaseDocument : BaseEntity
    {
        public string uniqueNo { get; set; } = string.Empty;
        public string? VsId { get; set; }
        public string? description { get; set; }
        public Guid CaseId { get; set; }
        public Case? Case { get; set; }
        public Guid? FileAssetId { get; set; }
        public FileEntity? FileAsset { get; set; }
        public Guid DocTypeId { get; set; }
        public DocType? DocType { get; set; }
    }
}
