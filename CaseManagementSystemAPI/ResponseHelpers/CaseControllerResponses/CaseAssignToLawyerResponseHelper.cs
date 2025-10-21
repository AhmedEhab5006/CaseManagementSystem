using CaseManagementSystemAPI.ResponseHandlers;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementSystemAPI.ResponseHelpers.CaseControllerResponses
{
    public class CaseAssignToLawyerResponseHelper
    {
        public static IActionResult Map(CaseAssignmentServiceValidatation result)
        {
            return result switch
            {
                CaseAssignmentServiceValidatation.done => new OkObjectResult(
                    new APIResponseHandler<string>(
                        200, "Success",
                        data: "Case(s) successfully assigned to lawyer(s) | تم إسناد القضايا بنجاح للمحامي")
                ),

                CaseAssignmentServiceValidatation.lawyerwasnnotfound => new BadRequestObjectResult(
                    new APIResponseHandler<string>(
                        400, "Bad Request",
                        data: "Desired lawyer wasn't found | المحامي المطلوب غير موجود")
                ),

                CaseAssignmentServiceValidatation.casewasnnotfound => new BadRequestObjectResult(
                    new APIResponseHandler<string>(
                        400, "Bad Request",
                        data: "Desired case wasn't found | القضية المطلوبة غير موجودة")
                ),

                CaseAssignmentServiceValidatation.error => new BadRequestObjectResult(
                    new APIResponseHandler<string>(
                        400, "Bad Request",
                        data: "An error occurred | حدث خطأ ما")
                ),

                _ => new BadRequestObjectResult(
                    new APIResponseHandler<string>(
                        400, "Bad Request",
                        data: "Unexpected result | نتيجة غير متوقعة")
                )
            };
        }
    
    }
}
