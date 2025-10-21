using CaseManagementSystemAPI.ResponseHandlers;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementSystemAPI.ResponseHelpers.CaseControllerResponses
{
    public class CaseAddResponseHelper
    {
        public static IActionResult Map(CaseAddServiceValidataion result)
        {
            return result switch
            {
                CaseAddServiceValidataion.Done => new OkObjectResult(
                    new APIResponseHandler<string>(200, "Success",
                        data: "Case Primary Data Was Added to System | تمت إضافة بيانات القضية الأساسية للنظام")
                ),

                CaseAddServiceValidataion.TypeWasnnotFound => new BadRequestObjectResult(
                    new APIResponseHandler<string>(400, "Bad Request",
                        data: "Desired Case Type Wasn't Found | نوع القضية المطلوب غير موجود")
                ),

                CaseAddServiceValidataion.TopicWasnnotFound => new BadRequestObjectResult(
                    new APIResponseHandler<string>(400, "Bad Request",
                        data: "Desired Case Topic Type Wasn't Found | موضوع القضية المطلوب غير موجود")
                ),

                CaseAddServiceValidataion.CourtWasnnotFound => new BadRequestObjectResult(
                    new APIResponseHandler<string>(400, "Bad Request",
                        data: "Desired Court Wasn't Found | المحكمة المطلوبة غير موجودة")
                ),

                CaseAddServiceValidataion.Error => new BadRequestObjectResult(
                    new APIResponseHandler<string>(400, "Bad Request",
                        data: "An Error Occurred! | حدث خطأ ما")
                ),

                _ => new BadRequestObjectResult(
                    new APIResponseHandler<string>(400, "Bad Request",
                        data: "Unexpected result | نتيجة غير متوقعة")
                )
            };
        }
    }
}
