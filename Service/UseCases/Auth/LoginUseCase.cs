using Application.Dto_s;
using Application.Interfaces;
using Application.Repositories.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Auth
{
    public class LoginUseCase(ILoginService _loginService)
    {
        public Task<string> Login(LoginDto loginDto)
        {
            return _loginService.Login(loginDto);
        }
    }
}
