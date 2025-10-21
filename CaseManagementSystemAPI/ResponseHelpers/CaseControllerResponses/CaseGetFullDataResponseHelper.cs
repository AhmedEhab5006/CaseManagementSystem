using Application.Dto_s.CaseDtos;
using CaseManagementSystemAPI.ResponseHandlers;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementSystemAPI.ResponseHelpers.CaseControllerResponses
{
    public class CaseGetFullDataResponseHelper
    {
        public static IActionResult Map(CaseFullDataReadDto? result)
        {
            return result is not null
                ? new OkObjectResult(
                    new APIResponseHandler<CaseFullDataReadDto?>(
                        200,
                        "Success",
                        data: result
                    )
                  )
                : new BadRequestObjectResult(
                    new APIResponseHandler<string>(
                        400,
                        "Not Found",
                        data: "There is No Data to Show | لا يوجد بيانات لعرضها"
                    )
                  );
        }
    }

}
