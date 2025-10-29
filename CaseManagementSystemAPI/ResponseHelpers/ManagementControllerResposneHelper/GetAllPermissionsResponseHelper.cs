using Application.Commons;
using Application.Dto_s.ManagementDto_s;
using CaseManagementSystemAPI.ResponseHandlers;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementSystemAPI.ResponseHelpers.ManagementControllerResposneHelper
{
    public class GetAllPermissionsResponseHelper
    {
        public static IActionResult Map(PagedResult<PermissionPrimaryDataReadDto> result)
        {
            return result switch
            {
                not null => new OkObjectResult(
                    new APIResponseHandler<PagedResult<PermissionPrimaryDataReadDto>>(
                        200,
                        "Success",
                        data: result
                    )
                  ),

                _ => new NotFoundObjectResult(
                new APIResponseHandler<string>(
                    404,
                    "Not Found",
                    data: "No Data To Show | لا يوجد بيانات لعرضها"
                )
              )
            };
        }
    }
}
