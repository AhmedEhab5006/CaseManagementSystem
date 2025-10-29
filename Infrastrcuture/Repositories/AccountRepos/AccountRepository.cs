using Application.Dto_s.AccountDto_s;
using Application.Repositories.AccountRepos;
using AutoMapper;
using Domain.Enums;
using Infrastrcuture.Auth;
using Infrastrcuture.Database;
using Infrastrcuture.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.Repositories.AccountRepos
{
    public class AccountRepository(ApplicationDbContext _context , IMapper _mapper) : IAccountRepository
    {
        public async Task<EditValidatation> EditAccountInfo(string accountId , AccountEditDto account)
        {
            var accountEntity = await _context.Users.FirstOrDefaultAsync(a => a.Id == accountId);
            var existingEmail = await _context.Users.FirstOrDefaultAsync(a=>a.Email == account.Email && a.Email != accountEntity.Email);
            var existingUserName = await _context.Users.FirstOrDefaultAsync(a=>a.UserName == account.username && a.UserName != accountEntity.UserName);

            if (existingEmail is not null || existingUserName is not null)
            {
                return EditValidatation.Taken;
            }

            if (accountEntity != null)
            {

                accountEntity.displayName = account.Name;
                accountEntity.ApplicationUserImagePath = account.Image;
                accountEntity.Email = account.Email;
                accountEntity.NormalizedEmail = account.Email.ToUpper();
                accountEntity.UserName = account.username;
                accountEntity.NormalizedUserName = account.username.ToUpper();
                accountEntity.ModifiedAt = account.ModifiedAt;
                accountEntity.ModifiedBy = account.ModifiedBy;

                _context.Users.Update(accountEntity);
                if(await _context.SaveChangesAsync() > 0)
                {
                    return EditValidatation.Edited;
                }

                return EditValidatation.Error;
            }

            return EditValidatation.NotFound;
        }

        public async Task<AccountReadDto?> GetAccountInfo(string accountId)
        {
            var account = await _context.Users.FirstOrDefaultAsync(a=>  a.Id == accountId && a.isDeleted == false);
            var returnedAccount = new AccountReadDto();

            if ( account is not null)
            {
                var role = await _context.UserRoles.FirstOrDefaultAsync(a => a.UserId == account.Id);

                if (role is not null) {
                    
                    var userRole = await _context.Roles.FirstOrDefaultAsync(a => a.Id == role.RoleId);
                    returnedAccount = _mapper.Map<AccountReadDto>(account);
                    
                    returnedAccount.Role = userRole.Name == "Admin" ? "مدير"
                           : userRole.Name == "Lawyer" ? "محامي"
                           : userRole.Name == "Registration Officer" ? "موظف تسجيل"
                           : "غير متاح"; 
                    
                    return returnedAccount;

                }
            }

            return null;
        }
    }
}
