using Application.Commands.LawyerCommands;
using Application.Commons;
using Application.Dto_s;
using Application.Dto_s.CaseDtos;
using Application.Queries.LawyerQueries;
using Application.UseCases.Auth;
using Application.UseCases.LawyerService;
using CaseManagementSystemAPI.ResponseHandlers;
using CaseManagementSystemAPI.ResponseHelpers.CaseControllerResponses;
using CaseManagementSystemAPI.ResponseHelpers.LawyerControllerResponseHelper;
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
        [Authorize(Roles = "Registration Officer")]
        public async Task<IActionResult> GetLawyerPrimaryDataById (string id)
        {
            var query = new GetLawyerPrimaryDataByIdQuery(id);
            var result = await _mediator.Send(query);
            return GetLawyerPrimaryDataByIdResponseHelper.Map(result);
        }

        [HttpGet("Get-Lawyers-For-Drop-Down-Menu")]
        [Authorize]
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
    }
}
