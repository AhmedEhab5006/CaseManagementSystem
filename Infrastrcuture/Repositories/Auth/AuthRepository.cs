using Application.Dto_s;
using Application.Dto_s.Commons;
using Application.Dto_s.ManagementDto_s;
using Application.Enums;
using Application.Repositories.Auth;
using AutoMapper;
using Domain.Enums;
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

        public async Task<AddValidation> AddUserAsync(UserAddDto userAddDto)
        {
            var emailExists = await CheckEmail(userAddDto.Email);
            var usernameExists = await CheckUsernameAsync(userAddDto.UserName);

            if (emailExists || usernameExists)
            {
                return AddValidation.AlreadyExist;
            }

            var roleDto = await GetRoleByIdAsync(userAddDto.RoleId);

            if (roleDto == null)
            {
                return AddValidation.RoleNotFound;
            }

            var roleEntity = await _context.Roles
                .FirstOrDefaultAsync(r => r.Id == userAddDto.RoleId);

            if (roleEntity == null)
            {
                return AddValidation.RoleNotFound;
            }

            var newUser = new ApplicationUser
            {
                UserName = userAddDto.UserName,
                Email = userAddDto.Email,
                NormalizedUserName = userAddDto.UserName.ToUpper(),
                NormalizedEmail = userAddDto.Email.ToUpper(),
                displayName = userAddDto.DisplayName,
                isActive = true,
                CreatedAt = DateTime.UtcNow,
                CreateedBy = userAddDto.createdBy,
                isDeleted = false,
                EmailConfirmed = true,
                LockoutEnabled = true,
                AccessFailedCount = 0,
            };

            var createResult = await _userManager.CreateAsync(newUser, userAddDto.Password);

            if (!createResult.Succeeded)
            {
                return AddValidation.Error;
            }

            var addToRoleResult = await _userManager.AddToRoleAsync(newUser, roleEntity.Name);

            if (!addToRoleResult.Succeeded)
            {
                await _userManager.DeleteAsync(newUser);
                return AddValidation.Error;
            }

            return AddValidation.Added;
        }

        public async Task<DeleteAndUpdateValidatation> DeleteUserAsync(string userId, DeleteDto delete)
        {
            var userEntity = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == userId && !u.isDeleted);

            if (userEntity == null)
            {
                return DeleteAndUpdateValidatation.DoesnotExist;
            }

            userEntity.isDeleted = true;
            userEntity.deletedAt = DateTime.Now;
            userEntity.deletedBy = delete.DeletedBy;
            userEntity.deletionReason = delete.DeletionReason;

            var userPermissions = await _context.UserPermissions
                .Where(up => up.UserId == userId && !up.isDeleted)
                .ToListAsync();

            if (userPermissions.Count > 0)
            {
                foreach (var userPermission in userPermissions)
                {
                    userPermission.isDeleted = true;
                    userPermission.deletedAt = delete.DeletedAt;
                    userPermission.deletedBy = delete.DeletedBy;
                    userPermission.deletionReason = delete.DeletionReason;
                }

                _context.UserPermissions.UpdateRange(userPermissions);
            }

            _context.Users.Update(userEntity);

            var saveResult = await _context.SaveChangesAsync();

            if (saveResult > 0)
            {
                return DeleteAndUpdateValidatation.Done;
            }

            return DeleteAndUpdateValidatation.Error;
        }

        public async Task<IEnumerable<RoleReadDto>> GetAllRolesAsync()
        {
            var roles = await _context.Roles
                .AsNoTracking()
                .ToListAsync();

            var roleDtos = roles.Select(role => new RoleReadDto
            {
                RoleId = role.Id,
                RoleName = role.Name switch
                {
                    "Admin" => "مدير",
                    "Lawyer" => "محامي",
                    "Registration Officer" => "موظف تسجيل",
                    _ => "غير متاح"
                }
            }).ToList();

            return roleDtos;
        }

        public async Task<IEnumerable<string>> GetUserPermissions(string userId)
        {
            var userPermissions = await _context.UserPermissions
                .Where(up => up.UserId == userId)
                .Join(_context.Permissions,
                      up => up.PermissionId,
                      p => p.id,
                      (up, p) => p.Name)
                .ToListAsync();

            var rolePermissions = await _context.UserRoles
                .Where(ur => ur.UserId == userId)
                .Join(_context.RolePermissions,
                      ur => ur.RoleId,
                      rp => rp.RoleId,
                      (ur, rp) => rp.PermissionId)
                .Join(_context.Permissions,
                      rpId => rpId,
                      p => p.id,
                      (rpId, p) => p.Name)
                .ToListAsync();

            return userPermissions.Concat(rolePermissions).Distinct();
        }
    }
}
