using Application.Dto_s;
using Application.Enums;
using Application.Repositories.Auth;
using AutoMapper;
using Domain.Entites.Permissions;
using Infrastrcuture.Auth;
using Infrastrcuture.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.Repositories.Auth
{
    public class AuthRepository(ApplicationDbContext _context , UserManager<ApplicationUser> _userManager , IMapper _mapper) : IAuthRepository
    {
        public async Task<bool> AddClaimsAsync(ApplicationUserReadDto user , Claim claim)
        {
            var userEntity = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == user.Id);
            
            if (userEntity == null)
                return false;
                
            await _userManager.AddClaimAsync(userEntity, claim);
            return true;
        }

        public async Task<bool> CheckEmail(string email)
        {
            var found = await _context.Users.Where(a => a.Email == email).Select(a => a.Email).FirstOrDefaultAsync();

            if (found is not null)
            {
                return true;
            }

            return false;

        }

        public async Task<bool> CheckPasswordAsync(string password, ApplicationUserReadDto user)
        {
            
            var userEntity = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == user.Id);
            
            if (userEntity == null)
                return false;

            return await _userManager.CheckPasswordAsync(userEntity, password);
        }

        public async Task<bool> CheckUsernameAsync(string username)
        {
            var found = await _context.Users.Where(a => a.UserName == username).Select(a => a.UserName).FirstOrDefaultAsync();

            if (found is not null)
            {
                return true;
            }

            return false;
        }

        public async Task<ApplicationUserReadDto?> FindByUsernameAsync(string username)
        {
            var found = await _userManager.Users
                            .AsNoTracking()
                            .FirstOrDefaultAsync(u => u.UserName == username);

            if (found is not null)
            {
                var user = _mapper.Map<ApplicationUserReadDto>(found);
                return user;
            }

            return null;
        }

        public async Task<ApplicationUserReadDto?> GetByEmailAsync(string email)
        {
            var found = await _userManager.Users
                          .AsNoTracking()
                          .FirstOrDefaultAsync(u => u.Email == email);

            if (found is not null)
            {
                var user = _mapper.Map<ApplicationUserReadDto>(found);
                return user;
            }

            return null;
        }

        public async Task<IList<Claim>> GetClaimsAsync(ApplicationUserReadDto user)
        {
            var userEntity = await _context.Users
                                .FirstOrDefaultAsync(u => u.Id == user.Id);

            if (userEntity == null)
                return null;

            var claims = await _userManager.GetClaimsAsync(userEntity);

            return claims.Count > 0 ? claims : null;
        }

        public async Task<ICollection<string>> GetUserRoleAsync(ApplicationUserReadDto user)
        {
            
            var userEntity = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == user.Id);
            
            if (userEntity == null)
                return new List<string>();
            
            return await _userManager.GetRolesAsync(userEntity);
        }

        public async Task<string> GenerateResetPassowrdTokenAsync(ApplicationUserReadDto user)
        {
            
            var userEntity = _userManager.Users.FirstOrDefault(a=>a.Id == user.Id);
            
            if (userEntity is not null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(userEntity);
                return token;
            }
            
            return ResetPasswordValidation.PasswordWasnotSent.ToString();

        }

        public async Task<bool> ResetPasswordAsync(ApplicationUserReadDto user, string token, string newPassword)
        {
           var userEntiy = await _context.Users.FirstOrDefaultAsync(a=>a.Email == user.Email);

            if ( userEntiy is not null)
            {
                var done = await _userManager.ResetPasswordAsync(userEntiy, token, newPassword);

                if (done.Succeeded)
                {
                    return true;
                }

            }

            return false;
        }

        public async Task<ApplicationUserReadDto?> GetByIdAsync(string Id)
        {
            var found = await _userManager.Users
                                  .AsNoTracking()
                                  .FirstOrDefaultAsync(u => u.Id == Id);

            if (found is not null)
            {
                var user = _mapper.Map<ApplicationUserReadDto>(found);
                return user;
            }

            return null;
        }

        public async Task<RoleReadDto?> GetRoleByIdAsync(string Id)
        {
            var found = await _context.Roles
                                             .AsNoTracking()
                                             .FirstOrDefaultAsync(u => u.Id == Id);

            if (found is not null)
            {
                var role = new RoleReadDto
                {
                    RoleId = found.Id,
                    RoleName = found.Name == "Admin"
                                            ? "مدير"
                                        : found.Name == "Lawyer"
                                        ? "محامي"
                                      : found.Name == "Registration Officer"
                                          ? "موظف تسجيل"
                                : "غير معروف",

                };


                return role;
            }

            return null;
        }
    }
}
