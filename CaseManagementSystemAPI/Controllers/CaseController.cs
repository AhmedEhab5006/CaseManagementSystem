using Application.Commons;
using Application.Dto_s.CaseDtos;
using Application.UseCases;
using Application.UseCases.Auth;
using CaseManagementSystemAPI.ResponseHandlers;
using Domain.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseController(ICaseService _caseService , IAuthService _authService) : ControllerBase
    {

        #region Add End Points

        [HttpPost("Add-Case-Primary-Data")]
        [Authorize(Roles = "Registration Officer")]
        public async Task<IActionResult> AddCasePrimaryData(CaseAddDto caseAddDto)
        {

            caseAddDto.createdBy = _authService.GetLoggedUserName();
            var result = await _caseService.AddCasePrimaryData(caseAddDto);


            if (result == Domain.Enums.CaseAddServiceValidataion.Done)
            {
                return Ok(new APIResponseHandler<string>(200, "Success", data: "Case Primary Data Was Added to System | تمت اضافة بيانات القضية الاساسية للنظام"));

            }

            if (result == Domain.Enums.CaseAddServiceValidataion.TypeWasnnotFound)
            {
                return NotFound(new APIResponseHandler<string>(404, "Not Found",
                    data: "Desired Case Type Wasn't Found | نوع القضية المطلوب غير موجود"));
            }


            if (result == Domain.Enums.CaseAddServiceValidataion.TopicWasnnotFound)
            {
                return NotFound(new APIResponseHandler<string>(404, "Not Found",
                    data: "Desired Case Topic Type Wasn't Found | موضوع القضية المطلوب غير موجود"));
            }

            if (result == Domain.Enums.CaseAddServiceValidataion.CourtWasnnotFound)
            {
                return NotFound(new APIResponseHandler<string>(404, "Not Found",
                    data: "Desired Court Wasn't Found | المحكمة المطلوبة غير موجودة"));
            }

            if (result == Domain.Enums.CaseAddServiceValidataion.CourtGradeWasnotFound)
            {
                return NotFound(new APIResponseHandler<string>(404, "Not Found",
                    data: "Desired Court Grade Wasn't Found | درجة المحكمة المطلوبة غير موجودة"));
            }

            return BadRequest(new APIResponseHandler<string>(400, "Bad Request", data: "An Error Occurred! | حدث خطأ ما"));


        }

        [HttpPost("Assign-Case-To-Lawyer")]
        [Authorize(Roles = "Registration Officer")]
        public async Task<IActionResult> AssignCaseToLawyer(CaseAssignmentDto caseAssignment)
        {

            caseAssignment.createdBy = _authService.GetLoggedUserName();
            caseAssignment.assignerId = _authService.GetLoggedId();

            var response = await _caseService.AssignCaseToLawyerAsync(caseAssignment);



            if (response == Domain.Enums.CaseAssignmentServiceValidatation.done)
            {
                return Ok(new APIResponseHandler<string>(200, "Success", data: "Case Was Sucssefully Assigned to the lawyer | تم اسناد القضية بنجاح للمحامي"));

            }

            if (response == Domain.Enums.CaseAssignmentServiceValidatation.lawyerwasnnotfound)
            {
                return NotFound(new APIResponseHandler<string>(404, "Not Found", 
                    data: "Desired Lawyer Wasn't Found | المحامي المطلوب غير موجود"));

            }


            if (response == Domain.Enums.CaseAssignmentServiceValidatation.casewasnnotfound)
            {
                return NotFound(new APIResponseHandler<string>(404, "Not Found",
                    data: "Desired Case Wasn't Found | القضية المطلوبة غير موجودة"));

            }


            else
            {
                return BadRequest(new APIResponseHandler<string>(400, "Bad Request",
                    data: "An Error Occurred | حدث خطأ ما"));

            }

        }


        [HttpPost("Add-Case-Topic")]
        [Authorize(Roles = "Registration Officer")]
        public async Task<IActionResult> AddCaseTopic(CaseTopicAddDto caseTopicAddDto)
        {
            caseTopicAddDto.createdBy = _authService.GetLoggedUserName();

            if(await _caseService.AddCaseTopicAsync(caseTopicAddDto))
            {
                return Ok(new APIResponseHandler<string>(200, "Success", 
                    data: "Case Topic Was Sucssefully Added | تمت اضافة موضوع القضية بنجاح"));

            }

            return BadRequest(new APIResponseHandler<string>(400, "Bad Request",
                    data: "An Error Occurred | حدث خطأ ما"));
        }

        [HttpPost("Add-Case-Type")]
        [Authorize(Roles = "Registration Officer")]
        public async Task<IActionResult> AddCaseType(CaseTypeAddDto caseTypeAddDto)
        {
            caseTypeAddDto.createdBy = _authService.GetLoggedUserName();

            if (await _caseService.AddCaseTypeAsync(caseTypeAddDto))
            {
                return Ok(new APIResponseHandler<string>(200, "Success",
                    data: "Case Type Was Sucssefully Added | تمت اضافة نوع القضية بنجاح"));

            }

            return BadRequest(new APIResponseHandler<string>(400, "Bad Request",
                    data: "An Error Occurred | حدث خطأ ما"));
        }


        [HttpPost("Add-Case-Litigant-Role")]
        [Authorize(Roles = "Registration Officer")]
        public async Task<IActionResult> AddCaseLitigantRole(CaseLitigantRoleDto caseLitigantAddDto)
        {
            caseLitigantAddDto.createdBy = _authService.GetLoggedUserName();

            if (await _caseService.AddCaseLitigantRoleAsync(caseLitigantAddDto))
            {
                return Ok(new APIResponseHandler<string>(200, "Success",
                    data: "Case Litigant Role Was Sucssefully Added | تمت اضافة صفة طرف القضية بنجاح"));

            }

            return BadRequest(new APIResponseHandler<string>(400, "Bad Request",
                    data: "An Error Occurred | حدث خطأ ما"));
        }


        [HttpPost("Add-Litigant")]
        [Authorize(Roles = "Registration Officer")]
        public async Task<IActionResult> AddLitigant(LitigantDto litigantAddDto)
        {
            litigantAddDto.createdBy = _authService.GetLoggedUserName();

            if (await _caseService.AddLitigantAsync(litigantAddDto))
            {
                return Ok(new APIResponseHandler<string>(200, "Success",
                    data: "Case Litigant Was Sucssefully Added | تمت اضافة طرف القضية بنجاح"));

            }

            return BadRequest(new APIResponseHandler<string>(400, "Bad Request",
                    data: "An Error Occurred | حدث خطأ ما"));
        }


        [HttpPost("Add-Case-Litigant")]
        [Authorize(Roles = "Registration Officer")]
        public async Task<IActionResult> AddCaseLitigant(CaseLtitgantDto caseLitigantAddDto)
        {
            caseLitigantAddDto.createdBy = _authService.GetLoggedUserName();

            var response = await _caseService.AddCaseLitigantAsync(caseLitigantAddDto);



            if (response == Domain.Enums.CaseLitigantAddVaildatation.done)
            {
                return Ok(new APIResponseHandler<string>(200, "Success", 
                    data: "Case Litigants Were Sucssefully Added " +
                    "| تمت اضافة اطراف القضية بنجاح"));

            }

            if (response == Domain.Enums.CaseLitigantAddVaildatation.casewasnotfound)
            {
                return NotFound(new APIResponseHandler<string>(404, "Not Found",
                    data: "Desired Case Wasn't Found | القضية المطلوبة غير موجودة"));

            }


            if (response == Domain.Enums.CaseLitigantAddVaildatation.litigantwasnotfound)
            {
                return NotFound(new APIResponseHandler<string>(404, "Not Found",
                    data: "Desired Litigant Wasn't Found | الطرف المطلوب غير موجود"));

            }

            if (response == Domain.Enums.CaseLitigantAddVaildatation.litigantrolewasnotfound)
            {
                return NotFound(new APIResponseHandler<string>(404, "Not Found",
                    data: "Desired Litigant Role Wasn't Found | صفة الطرف المطلوبة غير موجودة"));

            }

            else
            {
                return BadRequest(new APIResponseHandler<string>(400, "Bad Request",
                    data: "An Error Occurred | حدث خطأ ما"));

            }
        }

        #endregion

        #region Get End Points


        [HttpGet("Get-All-Cases-Primary-Data-{pageNumber}-{pageSize}")]
        [Authorize(Roles = "Registration Officer")]
        public async Task<IActionResult> GetAllCasesPrimaryData([FromRoute] int pageNumber , [FromRoute] int pageSize)
        {
            var records = await _caseService.GetAllCasesMainDataAsync(pageNumber, pageSize);

            if (records.TotalRecords > 0)
            {
                return Ok(new APIResponseHandler<PagedResult<CaseReadDto>>(200, "Success", 
                    data: records));
            }

            return NotFound(new APIResponseHandler<string>(404, "Not Found",
                data: "There is No Data to Show | لا يوجد بيانات لعرضها"));
        }


        [HttpGet("Get-Case-All-Data-{id}")]
        [Authorize(Roles = "Registration Officer")]
        public async Task <IActionResult> GetCaseFullData([FromRoute] Guid id)
        {
            var result = await _caseService.GetCaseAllDataAsync(id);

            if (result is not null)
            {
                return Ok(new APIResponseHandler<CaseFullDataReadDto?>(200, "Success",
                   data: result));
            }

            return NotFound(new APIResponseHandler<string>(404, "Not Found",
               data: "There is No Data to Show | لا يوجد بيانات لعرضها"));
        }


        [HttpGet("Get-Case-Litigant-Primary-Data-{id}-{pageNumber}-{pageSize}")]
        [Authorize(Roles = "Registration Officer")]
        public async Task<IActionResult> GetCaseLitigantsPrimaryData([FromRoute] Guid id , int pageNumber , int pageSize)
        {
            var result = await _caseService.GetCaseLitigantsAsync(pageNumber , pageSize , id);

            if (result is not null)
            {
                return Ok(new APIResponseHandler<PagedResult<LitigantReadDto>>(200, "Success",
                    data: result));
            }

            return NotFound(new APIResponseHandler<string>(404, "Not Found",
                data: "There is No Data to Show | لا يوجد بيانات لعرضها"));

         
        }


        [HttpGet("Get-Case-Litigant-Full-Data-{id}")]
        [Authorize(Roles = "Registration Officer")]
        public async Task<IActionResult> GetCaseLitigantsFullData([FromRoute] Guid id)
        {
            var result = await _caseService.GetCaseLitigantFullDataAsync(id);

            if (result is not null)
            {
                return Ok(new APIResponseHandler<LitigantDto>(200, "Success",
                    data: result));
            }

            return NotFound(new APIResponseHandler<string>(404, "Not Found",
                data: "There is No Data to Show | لا يوجد بيانات لعرضها"));


        }


        #endregion
    }
}
