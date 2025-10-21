using CaseManagementSystemAPI.ResponseHandlers;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CaseManagementSystemAPI.ResponseHelpers.CaseControllerResponses
{
    public class CaseAddLitigantResponseHelper
    {
        public static IActionResult Map(List<Guid> result)
        {
            return result.Count() switch
            {
                 > 0 => new OkObjectResult(
                   new APIResponseHandler<List<Guid>>(200, "Success",
                    data: result)),


                _ => new BadRequestObjectResult(
                     new APIResponseHandler<string>(
                         400, "Bad Request",
                         data: "An Error Occurred | حدث خطأ ما")
                 )
            };
        }
    }
}
