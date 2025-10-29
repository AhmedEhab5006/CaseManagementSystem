using Application.Commands.ManagementCommands;
using Application.Dto_s.Commons;
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

        [HttpDelete("Grant-Permission-From-User-{permissionId}-{userId}")]
        public async Task<IActionResult> GrantPermissionFromUser(Guid permissionId, string userId, DeleteDto deleteDto)
        {
            deleteDto.DeletedBy = _authService.GetLoggedUserName();
            var command = new GrantPermissionFromUserCommand(permissionId, userId , deleteDto);
            var result = await _mediator.Send(command);
            return DeleteAndUpdateResponseHelper.Map(result);

        }


        [HttpGet("Get-All-Permissions-{pageNumber}-{pageSize}")]
        public async Task<IActionResult> GetAllPermissions(int pageNumber , int pageSize)
        {
            var query = new GetAllPermissionsQuery(pageNumber , pageSize);
            var result = await _mediator.Send(query);
            return GetAllPermissionsResponseHelper.Map(result);

        }
    }
}
