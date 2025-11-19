using Application.Commons;
using CaseManagementSystemAPI.ResponseHandlers;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementSystemAPI.ResponseHelpers.ManagementControllerResposneHelper
{
    public class PagedResultResponseHelper
    {
        public static IActionResult Map<T>(PagedResult<T> result)
        {
            if (result == null || result.Data == null || !result.Data.Any())
            {
                return new NotFoundObjectResult(
                    new APIResponseHandler<string>(
                        404,
                        "Not Found",
                        data: "لا توجد بيانات لعرضها"
                    )
                );
            }

            return new OkObjectResult(
                new APIResponseHandler<PagedResult<T>>(
                    200,
                    "Success",
                    data: result
                )
            );
        }
    }
}
