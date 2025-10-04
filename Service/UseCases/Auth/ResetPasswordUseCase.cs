using Application.Dto_s;
using Application.Enums;
using Application.Interfaces;
using Application.Repositories.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Auth
{
    public class ResetPasswordUseCase(IAuthRepository _authRepository , ICacheService _cacheService) : IResetPasswordService
    {
        public async Task<string> GenerateResetPassowrdTokenAsync()
        {
            var found = await _authRepository.GetByEmailAsync(_cacheService.Get("email"));

            if (found is not null)
            {
                var token = await _authRepository.GenerateResetPassowrdTokenAsync(found);


                if (token != ResetPasswordValidation.PasswordWasnotSent.ToString())
                {
                    return token;
                }

                
            }

            return ResetPasswordValidation.PasswordWasnotSent.ToString();
        }

        public async Task<bool> ResetPasswordAsync(ApplicationUserReadDto user, string token, string newPassword)
        {
            if (await _authRepository.ResetPasswordAsync(user, token , newPassword))
            {
                return true;
            }

            return false;
        }
    }
}
