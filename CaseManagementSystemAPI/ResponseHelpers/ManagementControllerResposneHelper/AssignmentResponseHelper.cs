using CaseManagementSystemAPI.ResponseHandlers;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementSystemAPI.ResponseHelpers.ManagementControllerResposneHelper
{
    public class AssignmentResponseHelper
    {
        public static IActionResult Map(AssignValdiation result)
        {
            return result switch
            {
                AssignValdiation.Done => new OkObjectResult(
                    new APIResponseHandler<string>(
                        200,
                        "Success",
                        data: "Permission Was Sucessfully Given | تم اسناد الصلاحية بنجاح"
                    )
                  ),
                AssignValdiation.AlreadyAssigned => new BadRequestObjectResult(
                     new APIResponseHandler<string>(
                         400,
                         "Bad Request",
                         data: "Desired Assignee is Already Assigned | الطرف المراد اسناد الصلاحية له تم اسنادها له من قبل"
                     )
                   ),

                AssignValdiation.PermissionDoesnnotExtits => new NotFoundObjectResult(
                  new APIResponseHandler<string>(
                      404,
                      "Not Found",
                      data: "Desired Permission wasn't Found | الصلاحية المرادة غير موجودة"
                  )
                ),

                AssignValdiation.AssigedEntityDoesnotExist => new NotFoundObjectResult(
                new APIResponseHandler<string>(
                    404,
                    "Not Found",
                    data: "Desired Assignee Wasn't Found | الطرف المراد تعيين الصلاحية له غير موجود"
                )
              ),

                AssignValdiation.Error => new BadRequestObjectResult(
                 new APIResponseHandler<string>(
                     400,
                     "Bad Request",
                     data: "An Error Occured While Saving | حدث خطأ ما اثناء عملية الحفظ"
                 )
               ),

                _ => new BadRequestObjectResult(
                new APIResponseHandler<string>(
                    400,
                    "Bad Request",
                    data: "UnKnown Error | خطأ غير معروف"
                )
              )
            };
        }
    }
}
