using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Dto_s
{
    public class ApplicationUserReadDto
    {
            public string Id { get; set; }
            public string DisplayName { get; set; }
            public bool? IsActive { get; set; }
            public DateTime? CreatedAt { get; set; }
            public DateTime? CreatedBy { get; set; }
            public bool? IsDeleted { get; set; }
            public string UserName { get; set; }
            public string NormalizedUserName { get; set; }
            public string Email { get; set; }
            public string NormalizedEmail { get; set; }
            public bool? EmailConfirmed { get; set; }            
            public string PasswordHash { get; set; }
            public string SecurityStamp { get; set; }
            public string ConcurrencyStamp { get; set; }
            public string PhoneNumber { get; set; }
            public bool? PhoneNumberConfirmed { get; set; }
            public bool? TwoFactorEnabled { get; set; }
            public DateTimeOffset? LockoutEnd { get; set; }
            public bool? LockoutEnabled { get; set; }
            public int? AccessFailedCount { get; set; }
            public DateTime? ModifiedAt { get; set; }
            public DateTime? ModifiedBy { get; set; }
            public DateTime? DeletedAt { get; set; }
            public string DeletionReason { get; set; }
        }
    }

