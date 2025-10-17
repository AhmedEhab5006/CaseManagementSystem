using Application.Commons;
using Application.Dto_s;
using Application.Dto_s.CaseDtos;
using Application.UseCases.LawyerService;
using CaseManagementSystemAPI.ResponseHandlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LawyersController(ILawyerService _lawyerService) : ControllerBase
    {
        [HttpGet("Get-Lawyers-Primary-Data-{id}")]
        [Authorize(Roles = "Registration Officer")]
        public async Task<IActionResult> GetLawyerPrimaryDataById (string id)
        {
            var result = await _lawyerService.GetLawyerPrimaryDataById(id);

            if (result is not null)
            {
                return Ok(new APIResponseHandler<LawyerReadDto>(200, "Success",
                                  data: result));
            }

            return BadRequest(new APIResponseHandler<string>(400, "Not Found",
                          data: "There is No Data to Show | لا يوجد بيانات لعرضها"));
        }

        [HttpGet("Get-Lawyers-For-Drop-Down-Menu")]
        [Authorize(Roles = "Registration Officer")]
        public async Task<IActionResult> GetLawyersForDropDownMenuAsync()
        {
            var result = await _lawyerService.GetLawyersForDropDownMenuAsync();

            if (result is not null)
            {
                return Ok(new APIResponseHandler<IEnumerable<CaseDropDownMenuGetDto>>(200, "Success",
                                  data: result));
            }

            return BadRequest(new APIResponseHandler<string>(400, "Not Found",
                          data: "There is No Data to Show | لا يوجد بيانات لعرضها"));
        }
    }
}
