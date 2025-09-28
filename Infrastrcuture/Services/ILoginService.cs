using Application.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.Services
{
    public interface ILoginService
    {
        public Task<string> Login(LoginDto loginDto);

    }
}
