using Application.Dto_s;
using CaseManagementSystemAPI.ResponseHandlers;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementSystemAPI.ResponseHelpers.ManagementControllerResposneHelper
{
    public class AddPermissionResponseHelper
    {
        public static IActionResult Map(PermissionAddValidation result)
        {
            return result switch
            {
                PermissionAddValidation.Added => new OkObjectResult(
                    new APIResponseHandler<string>(
                        200,
                        "Success",
                        data: "Permission Was Sucessfully Added | تمت اضافة الصلاحية بنجاح"
                    )
                  ),
                PermissionAddValidation.AlreadyExist => new BadRequestObjectResult(
                     new APIResponseHandler<string>(
                         400,
                         "Bad Request",
                         data: "Desired Permission Already Exists | الصلاحية المراد اضافتها موجود بالفعل"
                     )
                   ),

                PermissionAddValidation.Error => new BadRequestObjectResult(
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
