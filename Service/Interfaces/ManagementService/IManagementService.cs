using Application.Commons;
using Application.Dto_s;
using Application.Dto_s.CaseDtos;
using Application.Dto_s.Commons;
using Application.Dto_s.CourtDto_s;
using Application.Dto_s.ManagementDto_s;
using Application.Dto_s.User;
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
        public Task<AddValidation> AddUserAsync(UserAddDto userAddDto);
        public Task<AddValidation> CourtAddAsync(CourtAddDto courtAddDto);
        public Task<DeleteAndUpdateValidatation> DeleteUserAsync(string userId, DeleteDto delete);
        public Task<DeleteAndUpdateValidatation> DeletePermissionAsync(Guid permissionId , DeleteDto delete);
        public Task<PagedResult<PermissionPrimaryDataReadDto>> GetAllPermissionsAsync(int pageNumber , int pageSize);
        public Task<PermissionPrimaryDataReadDto?> GetPermissionByIdAsync(Guid permissionId);
        public Task<PagedResult<PermissionPrimaryDataReadDto>> GetUserPermissionsAsync(string userId, int pageNumber, int pageSize);
        public Task<PagedResult<UserReadDto>> GetAllUsersAsync(int pageNumber, int pageSize);
        public Task<PagedResult<RolePermissionAssignmentReadDto>> GetAllAssignedRolesToPermissionAsync(Guid permissionId , int pageNumber, int pageSize);
        public Task<DeleteAndUpdateValidatation> UpdatePermissionAsync(Guid permissionId , PermissionUpdateDto permission);
        public Task<DeleteAndUpdateValidatation> GrantPermissionFromUserAsync(Guid permissionId , string userId , DeleteDto delete);
        public Task<DeleteAndUpdateValidatation> GrantPermissionFromRoleAsync(Guid permissionId , string roleId , DeleteDto delete);
        public Task<IEnumerable<RoleReadDto>> GetRolesForSlideMenuAsync();
        public Task<IEnumerable<CaseDropDownMenuGetDto>> GetPermissionsForDropDownMenuAsync();
        public Task<IEnumerable<CaseDropDownMenuGetDto>> GetCourtGradesForDropDownMenuAsync();
        public Task<PagedResult<CourtPrimaryDataReadDto>> GetAllCourtsPrimaryDataAsync(int pageNumber, int pageSize);
        public Task<CourtFullDataReadDto> GetAllCourtFullDataAsync(Guid CourtId);
        public Task<PagedResult<CaseReAssignmentRequestGetDto>> GetCaseReAssignmentRequests(int pageNumber, int pageSize);
        public Task<DeleteAndUpdateValidatation> AcceptCaseReAssignmentRequest(Guid requestId, BaseEditDto baseEdit);
        public Task<DeleteAndUpdateValidatation> RejectCaseReAssignmentRequest(Guid requestId, CaseReAssignmentRejectionDto caseReAssignmentRejectionDto);
    }
}
