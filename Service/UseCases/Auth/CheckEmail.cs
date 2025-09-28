using Application.Dto_s;
using Application.Repositories.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Auth
{
    public class CheckEmail (IAuthRepository _aAuthRepository)
    {
        public async Task<bool> Execute (EmailSendDto email)
        {
            var check = await _aAuthRepository.CheckEmail (email.email);
            return check;
        }
    }
}
