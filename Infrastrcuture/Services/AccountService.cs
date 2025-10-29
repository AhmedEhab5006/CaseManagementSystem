using Application.Dto_s.AccountDto_s;
using Application.Interfaces.AccountService;
using Application.Repositories.AccountRepos;
using Application.Repositories.Auth;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.Services
{
    public class AccountService(IAccountRepository _accountRepository , IAuthRepository _authRepository) : IAccountService
    {
        public async Task<EditValidatation> EditAccountInfo(string accountId, AccountEditDto account)
        {
            
            var user = await _authRepository.GetByIdAsync(accountId);
            var resetPasswordToken = await _authRepository.GenerateResetPassowrdTokenAsync(user);
            var passwordResetting =  await _authRepository.ResetPasswordAsync(user , resetPasswordToken , account.Password);
            
            if (!passwordResetting)
            {
                return EditValidatation.Error;
            }

            var resetUser = await _accountRepository.EditAccountInfo(accountId, account);
            return resetUser;
        
        }

        public async Task<AccountReadDto?> GetAccountInfo(string accountId)
        {
            var account = await _accountRepository.GetAccountInfo(accountId);
            return account;
        }
    }
}
