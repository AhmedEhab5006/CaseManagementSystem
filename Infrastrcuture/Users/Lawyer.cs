using Infrastrcuture.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.Users
{
    public class Lawyer : ApplicationUser
    {
        public int numberOfPendingCases { get; set; }
        public int numberOfCurrentCases { get; set; }
        public int numberOfEndedCases { get; set; }
    }
}
