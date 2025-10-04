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
    public class UserService(IAuthRepository _authRepository , ICacheService _cacheService) : IUserService
    {
        public Task<ApplicationUserReadDto> GetUserByEmail()
        {
            var found = _authRepository.GetByEmailAsync(_cacheService.Get("email"));

            if (found is not null)
            {
                return found;
            }

            return null;
        }
    }
}
