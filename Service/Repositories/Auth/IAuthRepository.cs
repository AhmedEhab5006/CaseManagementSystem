using Application.Dto_s;
using Application.Dto_s.Commons;
using Application.Dto_s.ManagementDto_s;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.Auth
{
    public interface IAuthRepository
    {
       public Task<bool> CheckEmail(string email);
       public Task<bool> CheckUsernameAsync(string username);
       public Task<bool> CheckPasswordAsync(string password, ApplicationUserReadDto user);
       public Task <ApplicationUserReadDto?> FindByUsernameAsync(string username);
       public Task<ICollection<string>> GetUserRoleAsync(ApplicationUserReadDto user);
       public Task <bool> AddClaimsAsync (ApplicationUserReadDto user , Claim claim);
       public Task <IList<Claim>> GetClaimsAsync (ApplicationUserReadDto user);
       public Task<string> GenerateResetPassowrdTokenAsync(ApplicationUserReadDto user);
       public Task<ApplicationUserReadDto?> GetByEmailAsync(string email);
       public Task<ApplicationUserReadDto?> GetByIdAsync(string Id);
       public Task<RoleReadDto?> GetRoleByIdAsync(string Id);
       public Task<bool> ResetPasswordAsync(ApplicationUserReadDto user , string token , string newPassword);
      public Task<AddValidation> AddUserAsync(UserAddDto userAddDto);
      public Task<DeleteAndUpdateValidatation> DeleteUserAsync(string userId, DeleteDto delete);
      public Task<IEnumerable<RoleReadDto>> GetAllRolesAsync();
      public Task<IEnumerable<string>> GetUserPermissions(string userId);
    

    }
}
