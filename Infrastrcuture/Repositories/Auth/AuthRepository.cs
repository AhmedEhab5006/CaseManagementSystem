using Application.Dto_s;
using Application.Repositories.Auth;
using AutoMapper;
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
            var userEntity = _mapper.Map<ApplicationUser>(user);
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
            
            var userEntity = _mapper.Map<ApplicationUser>(user);

            return await _userManager.CheckPasswordAsync(userEntity , password);


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

        public async Task<IList<Claim>> GetClaimsAsync(ApplicationUserReadDto user)
        {
            var userEntity = _mapper.Map<ApplicationUser>(user);
            
            var claims = await _userManager.GetClaimsAsync(userEntity);
            if (claims.Count > 0)
            {
                return claims;
            }

            return null;

        }

        public async Task<ICollection<string>> GetUserRoleAsync(ApplicationUserReadDto user)
        {
            var userEntity = _mapper.Map<ApplicationUser>(user);
            
            return await _userManager.GetRolesAsync(userEntity);

        }
    }
}
