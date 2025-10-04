using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Auth
{
    public interface IAuthService
    {
        public string GetLoggedUserName();
    }
}
