using Domain.Entites;
using Domain.Entites.Permissions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.Auth
{
    public class ApplicationUser : IdentityUser 
    {
        public string? displayName { get; set; }
        public bool isActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreateedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? deletedAt { get; set; }
        public string? deletedBy { get; set; }
        public string? deletionReason { get; set; }
        public bool isDeleted { get; set; }
        public string ApplicationUserImagePath { get; set; } = string.Empty;
        public ICollection<UserPermission>? UserPermissions { get; set; }
        public ICollection<ApplicationUserRole>? UserRoles { get; set; }


    }
}
