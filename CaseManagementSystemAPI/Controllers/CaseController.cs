using Application.Commands.CaseCommands.AddCommands;
using Application.Commons;
using Application.Dto_s;
using Application.Dto_s.CaseDtos;
using Application.Features.Case.Commands.AddCrimeToLitigant;
using Application.Handlers.CaseHandlers.CommandHandlers;
using Application.Queries.CaseQueries;
using Application.UseCases;
using Application.UseCases.Auth;
using CaseManagementSystemAPI.ResponseHandlers;
using CaseManagementSystemAPI.ResponseHelpers.CaseControllerResponses;
using Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseController(IAuthService _authService , IMediator _mediator) : ControllerBase
    {

        #region Add End Points

        [HttpPost("Add-Case-Primary-Data")]
        [Authorize(Roles = "Registration Officer")]
        public async Task<IActionResult> AddCasePrimaryData(CaseAddDto caseAddDto)
        {
            
            caseAddDto.createdBy = _authService.GetLoggedUserName();
            var command = new CaseAddCommand(caseAddDto);
            var result = await _mediator.Send(command);
            return CaseAddResponseHelper.Map(result);

        }


        [HttpPost("Assign-Case-To-Lawyer")]
        [Authorize(Roles = "Registration Officer")]
        public async Task<IActionResult> AssignCaseToLawyer(IEnumerable<CaseAssignmentDto> caseAssignments)
        {
           
            var createdBy = _authService.GetLoggedUserName();
            var assignerId = _authService.GetLoggedId();

            foreach (var assignment in caseAssignments)
            {
                assignment.createdBy = createdBy;
                assignment.assignerId = assignerId;
            }

            var command = new CaseAssignToLawyerCommand(caseAssignments);
            var result = await _mediator.Send(command);
            return CaseAssignToLawyerResponseHelper.Map(result);


        }


        [HttpPost("Add-Case-Topic")]
        [Authorize(Roles = "Registration Officer")]
        public async Task<IActionResult> AddCaseTopic(CaseTopicAddDto caseTopicAddDto)
        {
            caseTopicAddDto.createdBy = _authService.GetLoggedUserName();
            var command = new CaseTopicAddCommand(caseTopicAddDto);
            var result = await _mediator.Send(command);
            return CaseTopicAddResponseHelper.Map(result);

        }



        [HttpPost("Add-Case-Type")]
        [Authorize(Roles = "Registration Officer")]
        public async Task<IActionResult> AddCaseType(CaseTypeAddDto caseTypeAddDto)
        {
            caseTypeAddDto.createdBy = _authService.GetLoggedUserName();
            var command = new CaseAddTypeCommand(caseTypeAddDto);
            var result = await _mediator.Send(command);
            return CaseTypeAddResponseHelper.Map(result);
        }


        [HttpPost("Add-Case-Litigant-Role")]
        [Authorize(Roles = "Registration Officer")]
        public async Task<IActionResult> AddCaseLitigantRole(CaseLitigantRoleDto caseLitigantAddDto)
        {
            caseLitigantAddDto.createdBy = _authService.GetLoggedUserName();
            var command = new CaseAddLitigantRoleCommad(caseLitigantAddDto);
            var result = await _mediator.Send(command);
            return CaseAddLitigantRoleResponseHelper.Map(result);
        }


        [HttpPost("Add-Litigant")]
        [Authorize(Roles = "Registration Officer")]
        public async Task<IActionResult> AddLitigant(List<LitigantDto> litigantAddDto)
        {
            foreach (var litigant in litigantAddDto)
            {
                litigant.createdBy = _authService.GetLoggedUserName();
            }

            var command = new CaseAddLitigantCommand(litigantAddDto);
            var result = await _mediator.Send(command);
            return CaseAddLitigantResponseHelper.Map(result);

        }


        [HttpPost("Add-Case-Litigant")]
        [Authorize(Roles = "Registration Officer")]
        public async Task<IActionResult> AddCaseLitigant(List<CaseLtitgantDto> caseLitigantAddDto)
        {
            foreach (var litigant in caseLitigantAddDto)
            {
                litigant.createdBy = _authService.GetLoggedUserName();

            }

            var command = new CaseAddCaseLitigantCommand(caseLitigantAddDto);
            var result = await _mediator.Send(command);
            return CaseAddCaseLitigantResponseHelper.Map(result);

        }

        [HttpPost("Add-Crime-To-Litigant")]
        [Authorize(Roles = "Registration Officer")]
        public async Task<IActionResult> AddCaseLitigant(CrimeAddDto crimeAddDto)
        {
            var loggedUser = _authService.GetLoggedUserName();
            crimeAddDto.createdBy = loggedUser;
            var command = new AddCrimeCommand(crimeAddDto);
            var result = await _mediator.Send(command);
            return AddCrimeToLitigantResponseHelper.Map(result);

        }

        [HttpPost("Add-Case-Docs")]
        [Authorize(Roles = "Registration Officer")]
        public async Task<IActionResult> AddCaseDocument(CaseDocumentAddDto dto)
        {
            dto.createdBy = _authService.GetLoggedUserName();
            var command = new CaseDocsAddCommand(dto);
            var result = await _mediator.Send(command);
            return CaseDocumentAddResponseHelper.Map(result);

        }


        #endregion

        #region Get End Points


        [HttpGet("Get-All-Cases-Primary-Data-{pageNumber}-{pageSize}")]
        [Authorize(Roles = "Registration Officer,Admin")]
        public async Task<IActionResult> GetAllCasesPrimaryData([FromRoute] int pageNumber , [FromRoute] int pageSize)
        {

            var query = new GetAllQuery(pageNumber, pageSize);
            var result = await _mediator.Send(query);
            return CasePrimaryDataResponseHelper.Map(result);

        }


        [HttpGet("Get-Case-All-Data-{id}")]
        [Authorize]
        public async Task <IActionResult> GetCaseFullData([FromRoute] Guid id)
        {
            var query = new GetFullDataQuery(id);
            var result = await _mediator.Send(query);
            return CaseGetFullDataResponseHelper.Map(result);

        }


        [HttpGet("Get-Case-Litigant-Primary-Data-{id}-{pageNumber}-{pageSize}")]
        [Authorize]
        public async Task<IActionResult> GetCaseLitigantsPrimaryData([FromRoute] Guid id , int pageNumber , int pageSize)
        {
            var query = new GetCaseLitigantsPrimaryDataQuery(id, pageNumber, pageSize);
            var result = await _mediator.Send(query);
            return GetCaseLitigantsPrimaryDataResponseHelper.Map(result);
        
        }


        [HttpGet("Get-Case-Litigant-Full-Data-{id}")]
        [Authorize]
        public async Task<IActionResult> GetCaseLitigantsFullData([FromRoute] Guid id)
        {
         
            var query = new GetCaseLitigantFullDataQuery(id);
            var result = await _mediator.Send(query);
            return GetCaseLitigantFullDataResponseHelper.Map(result);

        }

        [HttpGet("Get-Case-Lawyers-Primary-Data-{caseId}-{pageNumber}-{pageSize}")]
        [Authorize]
        public async Task<IActionResult> GetCaseLawyersPrimaryData([FromRoute] Guid caseId , [FromRoute] int pageNumber , [FromRoute] int pageSize)
        {
            var query = new GetCaseLawyersPrimaryDataQuery(caseId, pageNumber, pageSize);
            var result = await _mediator.Send(query);
            return GetCaseLawyersPrimaryDataResposneHelper.Map(result);
        }

        [HttpGet("Get-Case-Lawyers-Full-Data-{lawyerId}")]
        [Authorize]
        public async Task<IActionResult> GetCaseLawyersFullData([FromRoute] string lawyerId)
        {
            var query = new GetLawyersFullDataQuery(lawyerId);
            var result = await _mediator.Send(query);
            return GetCaseLawyersFullDataResponseHelper.Map(result);
        }


        [HttpGet("Get-Case-Types-For-Drop-Down-List")]
        [Authorize(Roles = "Registration Officer")]
        public async Task<IActionResult> GetCaseTypesForDropDownMenu()
        {
            var query = new GetCaseTypesForDropDownMenuQuery();
            var result = await _mediator.Send(query);
            return GetDropMenuDataResponseHelper.Map(result);
        }

        [HttpGet("Get-Case-Topics-For-Drop-Down-List")]
        [Authorize(Roles = "Registration Officer")]
        public async Task<IActionResult> GetCaseTopicsForDropDownMenu()
        {
            var query = new GetCaseTopicsForDropDownMenuQuery();
            var result = await _mediator.Send(query);
            return GetDropMenuDataResponseHelper.Map(result);
        }

        [HttpGet("Get-Courts-For-Drop-Down-List")]
        [Authorize(Roles = "Registration Officer")]
        public async Task<IActionResult> GetCourtsForDropDownMenu()
        {
            var query = new GetCourtsForDropMenuQuery();
            var result = await _mediator.Send(query);
            return GetDropMenuDataResponseHelper.Map(result);
        }


        [HttpGet("Get-Litigants-Roles-For-Drop-Down-List")]
        [Authorize(Roles = "Registration Officer")]
        public async Task<IActionResult> GetLitigantsRolesForDropDownMenu()
        {
            var query = new GetLitigantRolesForDropMenuQuery();
            var result = await _mediator.Send(query);
            return GetDropMenuDataResponseHelper.Map(result);
        }

        [HttpGet("Get-Cirmes-For-Drop-Down-List")]
        [Authorize(Roles = "Registration Officer")]
        public async Task<IActionResult> GetCrimesForDropDownMenu()
        {
            var query = new GetCrimesForDropMenuQuery();
            var result = await _mediator.Send(query);
            return GetDropMenuDataResponseHelper.Map(result);
        }

        [HttpGet("Get-Litigant-Crimes-")]
        [Authorize(Roles = "Registration Officer")]
        public async Task<IActionResult> GetCrimesByLitigant([FromQuery] Guid caseId,[FromQuery] Guid litigantId,[FromQuery] int pageNumber = 1,[FromQuery] int pageSize = 10)
        {
            var query = new GetCrimesByLitigantQuery(caseId, litigantId, pageNumber, pageSize);
            var result = await _mediator.Send(query);

            return GetCrimesByLitigantResponseHelper.Map(result);
        }

        [HttpGet("Get-Case-History")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetCaseHistory([FromQuery] Guid caseId,[FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var query = new GetCaseHistoryQuery(caseId, pageNumber, pageSize);
            var result = await _mediator.Send(query);
            return GetCaseHistoryResponseHelper.Map(result);
        }
    }

    #endregion
}

