using Application.Dto_s.AccountDto_s;
using CaseManagementSystemAPI.ResponseHandlers;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementSystemAPI.ResponseHelpers.AccountControllerResponseHelper
{
    public class EditAccountInfoResponseHelper
    {
        public static IActionResult Map(EditValidatation result)
        {
            return result switch
            {
                EditValidatation.NotFound => new NotFoundObjectResult(
                   new APIResponseHandler<string>(
                       404, "NotFound",
                       data: "Desired Account Wasn't Found | الحساب المطلوب غير موجود")
               ),

                EditValidatation.Edited => new OkObjectResult(
                   new APIResponseHandler<string>(
                       200, "Sucsess",
                       data: "Edit was Done | تم التعديل بنجاح")
               ),

                EditValidatation.Error => new BadRequestObjectResult(
                   new APIResponseHandler<string>(
                       400, "BadRequest",
                       data: "an Error Occured During Editing Info | حدث خطأ ما اثناء عمليه التعديل")
                ),

                EditValidatation.Taken => new BadRequestObjectResult(
                            new APIResponseHandler<string>(
                             400, "BadRequest",
                            data: "Taken Email Or Username | بريد الكتروني او اسم مستخدم مأخوذ")
),


                _ => new BadRequestObjectResult(
                  new APIResponseHandler<string>(
                      400, "BadRequest",
                      data: "Unknown Error Occured | خطأ غير معروف")
               )

            };
        }
    }
}
