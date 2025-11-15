using CaseManagementSystemAPI.ResponseHandlers;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementSystemAPI.ResponseHelpers.ManagementControllerResposneHelper
{
    public class AddUserResponseHelper
    {
        public static IActionResult Map(AddValidation result)
        {
            return result switch
            {
                AddValidation.Added => new OkObjectResult(
                    new APIResponseHandler<string>(
                        200,
                        "Success",
                        data: "User Was Successfully Added | تمت اضافة المستخدم بنجاح"
                    )
                  ),
                AddValidation.AlreadyExist => new BadRequestObjectResult(
                     new APIResponseHandler<string>(
                         400,
                         "Bad Request",
                         data: "Desired User Already Exists | المستخدم المراد اضافته موجود بالفعل"
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
                      data: "An Error Occured While Saving Changes | حدث خطأ ما اثناء عملية حفظ البيانات"
                  )
                ),

                _ => new BadRequestObjectResult(
                new APIResponseHandler<string>(
                    400,
                    "Bad Request",
                    data: "Unknown Error Occured | حدث خطأ غير معروف"
                )
              )


            };
        }
    }
}

