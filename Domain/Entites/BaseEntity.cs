using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class BaseEntity
    {
        public Guid id { get; set; }
        public string createdBy { get; set; }
        public DateTime createdAt { get; set; }
        public string? updatedBy { get; set; }
        public DateTime? updatedAt { get; set; }
        public bool isDeleted { get; set; }
        public byte[]? rowVersion { get; set; }
        public string? deletedBy { get; set; }
        public DateTime? deletedAt { get; set; }
        public string? deletionReason { get; set; }
        public int versionNo { get; set; }


    }
}
