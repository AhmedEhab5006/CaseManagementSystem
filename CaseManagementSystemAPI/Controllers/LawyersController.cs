using Application.Commands.LawyerCommands;
using Application.Commons;
using Application.Dto_s;
using Application.Dto_s.CaseDtos;
using Application.Dto_s.Commons;
using Application.Dto_s.LawyerDto_s;
using Application.Queries.LawyerQueries;
using Application.UseCases.Auth;
using Application.UseCases.LawyerService;
using CaseManagementSystemAPI.ResponseHandlers;
using CaseManagementSystemAPI.ResponseHelpers.CaseControllerResponses;
using CaseManagementSystemAPI.ResponseHelpers.LawyerControllerResponseHelper;
using CaseManagementSystemAPI.ResponseHelpers.ManagementControllerResposneHelper;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LawyersController(IMediator _mediator , IAuthService _authService) : ControllerBase
    {
        [HttpGet("Get-Lawyers-Primary-Data-{id}")]
        [Authorize(Policy = "Users.View")]
        public async Task<IActionResult> GetLawyerPrimaryDataById (string id)
        {
            var query = new GetLawyerPrimaryDataByIdQuery(id);
            var result = await _mediator.Send(query);
            return GetLawyerPrimaryDataByIdResponseHelper.Map(result);
        }

        [HttpGet("Get-Lawyers-For-Drop-Down-Menu")]
        [Authorize(Policy = "Users.View")]
        public async Task<IActionResult> GetLawyersForDropDownMenuAsync()
        {
            var query = new GetLawyersForDropMenuQuery();
            var result = await _mediator.Send(query);
            return GetDropMenuDataResponseHelper.Map(result);
        }

        [HttpGet("Get-My-Assigned-Cases")]
        [Authorize(Roles = "Lawyer")]
        public async Task<IActionResult> GetMyAssignedCases(int pageNumber , int pageSize)
        {
            var lawyerId = _authService.GetLoggedId();
            var query = new GetMyAssignedCasesQuery(lawyerId , pageNumber , pageSize);
            var result = await _mediator.Send(query);
            return GetMyAssignedCasesResponseHelper.Map(result);
        }


        [HttpGet("Get-My-Current-Cases")]
        [Authorize(Roles = "Lawyer")]
        public async Task<IActionResult> GetMyCurrentCases(int pageNumber, int pageSize)
        {
            var lawyerId = _authService.GetLoggedId();
            var query = new GetCurrentCasesQuery(lawyerId, pageNumber, pageSize);
            var result = await _mediator.Send(query);
            return GetMyAssignedCasesResponseHelper.Map(result);
        }

        [HttpPost("Send-Case-ReAssignment-Request")]
        [Authorize(Roles = "Lawyer")]
        public async Task<IActionResult> SendCaseReAssignmentRequest(CaseReAssignmentRequestDto dto)
        {
            var assignerId = _authService.GetLoggedId();
            var createdBy = _authService.GetLoggedUserName();
            dto.AssignerId = assignerId;
            dto.createdBy = createdBy;
            var command = new SendCaseReAssignmentRequestCommand(dto);
            var result = await _mediator.Send(command);
            return SendCaseReAssignmentRequestResponseHelper.Map(result);
        }


        [HttpPut("Accept-Case-Initial-Assignment-Request")]
        [Authorize(Roles = "Lawyer")]
        public async Task<IActionResult> AcceptCaseInitialAssignmentRequest(Guid caseId)
        {
            var acceptedBy = _authService.GetLoggedUserName();
            var command = new ApproveCaseAssignmentCommand(caseId , acceptedBy);
            var result = await _mediator.Send(command);
            return DeleteAndUpdateResponseHelper.Map(result);
        }

        [HttpGet("Get-ReAssignment-Requests")]
        [Authorize(Roles = "Lawyer")]
        public async Task<IActionResult> GetReAssignmentRequests(int pageNumber , int pageSize)
        {
            var current = _authService.GetLoggedId();
            var query = new GetMyReAssignmentRequestsQuery(current , pageNumber , pageSize);
            var result = await _mediator.Send(query);
            return PagedResultResponseHelper.Map(result);
        }

        [HttpPut("Revoke-ReAssignment-Request")]
        [Authorize(Roles = "Lawyer")]
        public async Task<IActionResult> RevokeReAssignmentRequest(Guid requestId , [FromBody] DeleteDto deleteDto)
        {
            var assignerId =  _authService.GetLoggedId();
            deleteDto.DeletedBy =  _authService.GetLoggedUserName();
            var command = new RevokeReAssignmentRequestCommand(requestId, assignerId, deleteDto);
            var result = await _mediator.Send(command);
            return DeleteAndUpdateResponseHelper.Map(result);
        }

        [HttpPut("Close-Case/{caseId}")]
        [Authorize(Policy = "Cases.Close")]
        public async Task<IActionResult> CloseCase(Guid caseId, CloseCaseDto close)
        {
            close.lawyerId = _authService.GetLoggedId();
            close.ModifiedBy = _authService.GetLoggedUserName();
            var command = new CloseCaseCommand(caseId, close);
            var result = await _mediator.Send(command);
            return DeleteAndUpdateResponseHelper.Map(result);
        }
    }

}
