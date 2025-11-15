using Application.Commands.ManagementCommands;
using Application.Dto_s.Commons;
using Application.Dto_s.CourtDto_s;
using Application.Dto_s.ManagementDto_s;
using Application.Queries.ManagementQueries;
using Application.UseCases.Auth;
using CaseManagementSystemAPI.ResponseHelpers.ManagementControllerResposneHelper;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class ManagementController(IAuthService _authService , IMediator _mediator) : ControllerBase
    {
        [HttpPost("Add-Permission")]
        public async Task<IActionResult> AddPermission(PermissionDto permissionDto)
        {
            permissionDto.createdBy = _authService.GetLoggedUserName();
            var command = new AddPermissionCommand(permissionDto);
            var result = await _mediator.Send(command);
            return AddPermissionResponseHelper.Map(result);

        }

        [HttpPost("Add-User")]
        public async Task<IActionResult> AddUser(UserAddDto userAddDto)
        {
            userAddDto.createdBy = _authService.GetLoggedUserName();
            var command = new AddUserCommand(userAddDto);
            var result = await _mediator.Send(command);
            return AddUserResponseHelper.Map(result);
        }

        [HttpPost("Add-Court")]
        public async Task<IActionResult> AddCourt(CourtAddDto courtAddDto)
        {
            courtAddDto.createdBy = _authService.GetLoggedUserName();
            var command = new CourtAddCommand(courtAddDto);
            var result = await _mediator.Send(command);
            return CourtAddResponseHelper.Map(result);
        }

        [HttpPut("Delete-User-{userId}")]
        public async Task<IActionResult> DeleteUser(string userId, DeleteDto deleteDto)
        {
            deleteDto.DeletedBy = _authService.GetLoggedUserName();
            var command = new DeleteUserCommand(userId, deleteDto);
            var result = await _mediator.Send(command);
            return DeleteAndUpdateResponseHelper.Map(result);
        }

        [HttpPost("Assign-Role-To-Permission")]
        public async Task<IActionResult> AssignRoleToPermission(PermissionAssignmentDto permissionAssignmentDto)
        {
            permissionAssignmentDto.createdBy = _authService.GetLoggedUserName();
            var command = new AssignRoleToPermissionCommand(permissionAssignmentDto);
            var result = await _mediator.Send(command);
            return AssignmentResponseHelper.Map(result);

        }

        [HttpPost("Assign-User-To-Permission")]
        public async Task<IActionResult> AssignUserToPermission(PermissionAssignmentDto permissionAssignmentDto)
        {
            permissionAssignmentDto.createdBy = _authService.GetLoggedUserName();
            var command = new AssignUserToPermissionCommand(permissionAssignmentDto);
            var result = await _mediator.Send(command);
            return AssignmentResponseHelper.Map(result);

        }

        [HttpPut("Update-Permission-{id}")]
        public async Task<IActionResult> UpdatePermission(Guid id , PermissionUpdateDto permissionUpdateDto)
        {
            permissionUpdateDto.ModifiedBy = _authService.GetLoggedUserName();
            var command = new UpdatePermissionCommand(id , permissionUpdateDto);
            var result = await _mediator.Send(command);
            return DeleteAndUpdateResponseHelper.Map(result);

        }


        [HttpDelete("Delete-Permission-{permissionId}")]
        public async Task<IActionResult> DeletePermission(Guid permissionId , DeleteDto deleteDto)
        {
            deleteDto.DeletedBy = _authService.GetLoggedUserName();
            var command = new DeletePermissionCommand(permissionId , deleteDto);
            var result = await _mediator.Send(command);
            return DeleteAndUpdateResponseHelper.Map(result);

        }

        [HttpDelete("Grant-Permission-From-Role-{permissionId}-{roleId}")]
        public async Task<IActionResult> GrantPermissionFromRole(Guid permissionId , string roleId , DeleteDto deleteDto)
        {
            deleteDto.DeletedBy = _authService.GetLoggedUserName();
            var command = new GrantPermissionFromRoleCommand(permissionId, roleId, deleteDto);
            var result = await _mediator.Send(command);
            return DeleteAndUpdateResponseHelper.Map(result);

        }

        [HttpPut("Grant-Permission-From-User/{permissionId}/{userId}")]
        public async Task<IActionResult> GrantPermissionFromUser(string permissionId, string userId, DeleteDto deleteDto)
        {
            deleteDto.DeletedBy = _authService.GetLoggedUserName();
            var command = new GrantPermissionFromUserCommand(new Guid(permissionId), userId , deleteDto);
            var result = await _mediator.Send(command);
            return DeleteAndUpdateResponseHelper.Map(result);

        }


        [HttpGet("Get-All-Permissions-{pageNumber}-{pageSize}")]
        public async Task<IActionResult> GetAllPermissions(int pageNumber , int pageSize)
        {
            var query = new GetAllPermissionsQuery(pageSize, pageNumber);
            var result = await _mediator.Send(query);
            return GetAllPermissionsResponseHelper.Map(result);

        }

        [HttpGet("Get-Permission-By-Id-{permissionId}")]
        public async Task<IActionResult> GetPermissionById(Guid permissionId)
        {
            var query = new GetPermissionByIdQuery(permissionId);
            var result = await _mediator.Send(query);
            return GetPermissionByIdResponseHelper.Map(result);
        }

        [HttpGet("Get-All-Users-{pageNumber}-{pageSize}")]
        public async Task<IActionResult> GetAllUsers(int pageNumber, int pageSize)
        {
            var query = new GetAllUsersQuery(pageSize, pageNumber);
            var result = await _mediator.Send(query);
            return GetAllUsersResponseHelper.Map(result);
        }

        [HttpGet("Get-All-Courts-Primary-Data-{pageNumber}-{pageSize}")]
        public async Task<IActionResult> GetAllCourtsPrimaryData(int pageNumber, int pageSize)
        {
            var query = new GetAllCourtsPrimaryDataQuery(pageSize, pageNumber);
            var result = await _mediator.Send(query);
            return GetAllCourtsPrimaryDataResponseHelper.Map(result);
        }

        [HttpGet("Get-Court-Full-Data-{courtId}")]
        public async Task<IActionResult> GetCourtFullData([FromRoute] Guid courtId)
        {
            var query = new GetCourtFullDataQuery(courtId);
            var result = await _mediator.Send(query);
            return GetCourtFullDataResponseHelper.Map(result);
        }

        [HttpGet("Get-User-Permissions-{userId}-{pageNumber}-{pageSize}")]
        public async Task<IActionResult> GetUserPermissions(string userId, int pageNumber, int pageSize)
        {
            var query = new GetUserPermissionsQuery(userId, pageSize, pageNumber);
            var result = await _mediator.Send(query);
            return GetUserPermissionsResponseHelper.Map(result);
        }

        [HttpGet("Get-All-Roles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var query = new GetAllRolesQuery();
            var result = await _mediator.Send(query);
            return GetAllRolesResponseHelper.Map(result);
        }

        [HttpGet("Get-Permissions-For-Drop-Down-Menu")]
        public async Task<IActionResult> GetPermissionsForDropDownMenu()
        {
            var query = new GetPermissionsForDropDownMenuQuery();
            var result = await _mediator.Send(query);
            return GetPermissionsForDropDownMenuResponseHelper.Map(result);
        }

        [HttpGet("Get-Court-Grades-For-Drop-Down-Menu")]
        public async Task<IActionResult> GetCourtGradesForDropDownMenu()
        {
            var query = new GetCourtGradesForDropDownMenuQuery();
            var result = await _mediator.Send(query);
            return GetCourtGradesForDropDownMenuResponseHelper.Map(result);
        }

        [HttpGet("Get-Entity-Audit-{id}-{pageNumber}-{pageSize}")]
        public async Task<IActionResult> GetEntityAudit(Guid id , int pageNumber , int pageSize)
        {
            var query = new GetEntityAuditQuery(id , pageNumber , pageSize);
            var result = await _mediator.Send(query);
            return GetEntityAuditResponseHelper.Map(result);
        }

        [HttpGet("Get-Case-ReAssignment-Requests-{pageNumber}-{pageSize}")]
        public async Task<IActionResult> GetCaseReAssignmentRequests(int pageNumber, int pageSize)
        {
            var query = new GetCaseReAssignmentRequestsQuery(pageSize, pageNumber);
            var result = await _mediator.Send(query);
            return GetCaseReAssignmentRequestsResponseHelper.Map(result);
        }
    }
}
