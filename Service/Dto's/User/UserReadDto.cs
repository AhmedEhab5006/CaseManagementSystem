using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto_s.User
{
    public class UserReadDto
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string IsActive { get; set; }
        public string CreatedAt { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
