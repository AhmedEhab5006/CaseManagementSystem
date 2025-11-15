using Application.Dto_s.CourtDto_s;
using CaseManagementSystemAPI.ResponseHandlers;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CaseManagementSystemAPI.ResponseHelpers.ManagementControllerResposneHelper
{
    public class GetCourtFullDataResponseHelper
    {
        public static IActionResult Map(CourtFullDataReadDto result)
        {
            // Check if the court was found by checking if CourtId is not empty
            // If court is not found, the service returns an empty DTO with default values
            return result.CourtId != Guid.Empty
                ? new OkObjectResult(
                    new APIResponseHandler<CourtFullDataReadDto>(
                        200,
                        "Success",
                        data: result
                    )
                  )
                : new NotFoundObjectResult(
                    new APIResponseHandler<string>(
                        404,
                        "Not Found",
                        data: "Court Wasn't Found | المحكمة المطلوبة غير موجودة"
                    )
                  );
        }
    }
}

