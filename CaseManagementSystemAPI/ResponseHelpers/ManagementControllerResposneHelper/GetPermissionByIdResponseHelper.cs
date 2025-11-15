using Application.Dto_s.ManagementDto_s;
using CaseManagementSystemAPI.ResponseHandlers;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementSystemAPI.ResponseHelpers.ManagementControllerResposneHelper
{
    public class GetPermissionByIdResponseHelper
    {
        public static IActionResult Map(PermissionPrimaryDataReadDto? result)
        {
            return result is not null
                ? new OkObjectResult(
                    new APIResponseHandler<PermissionPrimaryDataReadDto>(
                        200,
                        "Success",
                        data: result
                    )
                  )
                : new NotFoundObjectResult(
                    new APIResponseHandler<string>(
                        404,
                        "Not Found",
                        data: "Permission Wasn't Found | الصلاحية المطلوبة غير موجودة"
                    )
                  );
        }
    }
}

