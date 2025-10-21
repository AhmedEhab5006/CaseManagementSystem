using CaseManagementSystemAPI.ResponseHandlers;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementSystemAPI.ResponseHelpers.CaseControllerResponses
{
    public class CaseAddCaseLitigantResponseHelper
    {
        public static IActionResult Map(CaseLitigantAddVaildatation result)
        {
            return result switch
            {
                CaseLitigantAddVaildatation.done => new OkObjectResult(
                    new APIResponseHandler<string>(
                        200, "Success",
                        data: "Case Litigants Were Successfully Added | تمت إضافة أطراف القضية بنجاح")
                ),

                CaseLitigantAddVaildatation.casewasnotfound => new BadRequestObjectResult(
                    new APIResponseHandler<string>(
                        400, "Bad Request",
                        data: "Desired Case Wasn't Found | القضية المطلوبة غير موجودة")
                ),

                CaseLitigantAddVaildatation.litigantwasnotfound => new BadRequestObjectResult(
                    new APIResponseHandler<string>(
                        400, "Bad Request",
                        data: "Desired Litigant Wasn't Found | الطرف المطلوب غير موجود")
                ),

                CaseLitigantAddVaildatation.litigantrolewasnotfound => new BadRequestObjectResult(
                    new APIResponseHandler<string>(
                        400, "Bad Request",
                        data: "Desired Litigant Role Wasn't Found | صفة الطرف المطلوبة غير موجودة")
                ),

                CaseLitigantAddVaildatation.error => new BadRequestObjectResult(
                    new APIResponseHandler<string>(
                        400, "Bad Request",
                        data: "An Error Occurred | حدث خطأ ما")
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
