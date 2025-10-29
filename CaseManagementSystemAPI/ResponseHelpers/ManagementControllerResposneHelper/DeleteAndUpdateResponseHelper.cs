using CaseManagementSystemAPI.ResponseHandlers;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementSystemAPI.ResponseHelpers.ManagementControllerResposneHelper
{
    public class DeleteAndUpdateResponseHelper
    {
        public static IActionResult Map(DeleteAndUpdateValidatation result)
        {
            return result switch
            {
                DeleteAndUpdateValidatation.Done => new OkObjectResult(
                    new APIResponseHandler<string>(
                        200,
                        "Success",
                        data: "Process was Sucessfully Done | تمت العملية بنجاح"
                    )
                  ),

                DeleteAndUpdateValidatation.DoesnotExist => new NotFoundObjectResult(
                  new APIResponseHandler<string>(
                      404,
                      "Not Found",
                      data: "Desired Entity wasn't Found | الكيان المراد غير موجود"
                  )
                ),

                DeleteAndUpdateValidatation.Error => new BadRequestObjectResult(
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
