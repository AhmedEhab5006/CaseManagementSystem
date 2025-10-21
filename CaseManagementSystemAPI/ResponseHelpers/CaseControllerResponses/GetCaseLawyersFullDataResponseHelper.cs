using Application.Dto_s.CaseDtos;
using CaseManagementSystemAPI.ResponseHandlers;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementSystemAPI.ResponseHelpers.CaseControllerResponses
{
    public class GetCaseLawyersFullDataResponseHelper
    {
        public static IActionResult Map(LawyerFullDataReadDto? result)
        {
            return result is not null
                ? new OkObjectResult(
                    new APIResponseHandler<LawyerFullDataReadDto>(
                        200,
                        "Success",
                        data: result
                    )
                  )
                : new BadRequestObjectResult(
                    new APIResponseHandler<string>(
                        404,
                        "Not Found",
                        data: "There is No Data to Show | لا يوجد بيانات لعرضها"
                    )
                  );
        }

    }
}
