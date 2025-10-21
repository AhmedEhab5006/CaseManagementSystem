using CaseManagementSystemAPI.ResponseHandlers;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementSystemAPI.ResponseHelpers.OmaniGoverantesControllerResponseHelper
{
    public class GetResponseHelper
    {
        public static IActionResult Map(IEnumerable<string>? result)
        {
          
            return result is not null && result.Any()
                ? new OkObjectResult(
                    new APIResponseHandler<IEnumerable<string>>(
                        200,
                        "Success",
                        data: result
                    )
                )
                : new BadRequestObjectResult(
                    new APIResponseHandler<string>(
                        404,
                        "Not Found",
                        data: "No Wilayats found for the specified governorate | لا توجد ولايات للمحافظة المحددة"
                    )
                );
        }

    }
}
