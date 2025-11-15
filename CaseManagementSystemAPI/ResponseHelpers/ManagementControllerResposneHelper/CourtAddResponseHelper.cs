using CaseManagementSystemAPI.ResponseHandlers;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementSystemAPI.ResponseHelpers.ManagementControllerResposneHelper
{
    public class CourtAddResponseHelper
    {
        public static IActionResult Map(AddValidation result)
        {
            return result switch
            {
                AddValidation.Added => new OkObjectResult(
                    new APIResponseHandler<string>(
                        200,
                        "Success",
                        data: "Court Was Successfully Added | تمت اضافة المحكمة بنجاح"
                    )
                  ),
                AddValidation.AlreadyExist => new BadRequestObjectResult(
                     new APIResponseHandler<string>(
                         400,
                         "Bad Request",
                         data: "Court With This Name Already Exists | المحكمة بهذا الاسم موجودة بالفعل"
                     )
                   ),

                AddValidation.RoleNotFound => new NotFoundObjectResult(
                  new APIResponseHandler<string>(
                      404,
                      "Not Found",
                      data: "Desired Role Wasn't Found | الدور المطلوب غير موجود"
                  )
                ),

                AddValidation.Error => new BadRequestObjectResult(
                  new APIResponseHandler<string>(
                      400,
                      "Bad Request",
                      data: "An Error Occurred. Court Grade May Not Exist Or Error Saving Changes | حدث خطأ ما. قد تكون درجة المحكمة غير موجودة أو حدث خطأ أثناء عملية حفظ البيانات"
                  )
                ),

                _ => new BadRequestObjectResult(
                new APIResponseHandler<string>(
                    400,
                    "Bad Request",
                    data: "Unknown Error Occurred | حدث خطأ غير معروف"
                )
              )


            };
        }
    }
}

