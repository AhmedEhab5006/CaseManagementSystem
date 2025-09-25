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
        public bool isDeleted { get; set; }
    }
}
