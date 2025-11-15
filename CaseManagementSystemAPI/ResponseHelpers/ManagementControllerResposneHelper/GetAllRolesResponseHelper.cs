using Application.Dto_s;
using CaseManagementSystemAPI.ResponseHandlers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CaseManagementSystemAPI.ResponseHelpers.ManagementControllerResposneHelper
{
    public class GetAllRolesResponseHelper
    {
        public static IActionResult Map(IEnumerable<RoleReadDto> result)
        {
            return result switch
            {
                not null => new OkObjectResult(
                    new APIResponseHandler<IEnumerable<RoleReadDto>>(
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

