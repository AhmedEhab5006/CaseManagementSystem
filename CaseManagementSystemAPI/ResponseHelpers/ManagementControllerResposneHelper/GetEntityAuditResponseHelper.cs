using Application.Commons;
using Application.Dto_s.Audting;
using Application.Dto_s.ManagementDto_s;
using CaseManagementSystemAPI.ResponseHandlers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CaseManagementSystemAPI.ResponseHelpers.ManagementControllerResposneHelper
{
    public class GetEntityAuditResponseHelper
    {
        public static IActionResult Map(PagedResult<AuditGetDto> result)
        {
            return result switch
            {
                not null => new OkObjectResult(
                    new APIResponseHandler<PagedResult<AuditGetDto>>(
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

