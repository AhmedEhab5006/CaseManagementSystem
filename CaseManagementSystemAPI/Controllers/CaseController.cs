using Application.Dto_s.CaseDtos;
using Application.UseCases;
using Application.UseCases.Auth;
using CaseManagementSystemAPI.ResponseHandlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseController(ICaseService _caseService , IAuthService _authService) : ControllerBase
    {
        [HttpPost("Add-Case-Primary-Data")]
        [Authorize(Roles = "Registration Officer")]

        public async Task<IActionResult> AddCasePrimaryData(CaseAddDto caseAddDto)
        {

            caseAddDto.createdBy = _authService.GetLoggedUserName();
            
            if(await _caseService.AddCasePrimaryData(caseAddDto))
            {
                return Ok(new APIResponseHandler<string>(200, "Success", data: "Case Primary Data Was Added to System | تمت اضافة بيانات القضية الاساسية للنظام"));

            }

            return BadRequest(new APIResponseHandler<string>(400, "Bad Request", data: "An Error Occurred! | حدث خطأ ما"));


        }

    }
}
