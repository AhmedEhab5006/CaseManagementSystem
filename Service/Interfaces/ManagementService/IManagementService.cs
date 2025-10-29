using Application.Commons;
using Application.Dto_s.Commons;
using Application.Dto_s.ManagementDto_s;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ManagementService
{
    public interface IManagementService
    {
        public Task<AssignValdiation> AssignUserToPermissionAsync(PermissionAssignmentDto permissionAssignment);
        public Task<AssignValdiation> AssignRoleToPermissionAsync(PermissionAssignmentDto permissionAssignment);
        public Task<PermissionAddValidation> AddPermissionAsync(PermissionDto permission);
        public Task<DeleteAndUpdateValidatation> DeletePermissionAsync(Guid permissionId , DeleteDto delete);
        public Task<PagedResult<PermissionPrimaryDataReadDto>> GetAllPermissionsAsync(int pageNumber , int pageSize);
        public Task<PagedResult<PermissionUserAssignmentReadDto>> GetAllAssignedUsersToPermissionAsync(Guid permissionId , int pageNumber, int pageSize);
        public Task<PagedResult<RolePermissionAssignmentReadDto>> GetAllAssignedRolesToPermissionAsync(Guid permissionId , int pageNumber, int pageSize);
        public Task<DeleteAndUpdateValidatation> UpdatePermissionAsync(Guid permissionId , PermissionUpdateDto permission);
        public Task<DeleteAndUpdateValidatation> GrantPermissionFromUserAsync(Guid permissionId , string userId , DeleteDto delete);
        public Task<DeleteAndUpdateValidatation> GrantPermissionFromRoleAsync(Guid permissionId , string roleId , DeleteDto delete);
    }
}
