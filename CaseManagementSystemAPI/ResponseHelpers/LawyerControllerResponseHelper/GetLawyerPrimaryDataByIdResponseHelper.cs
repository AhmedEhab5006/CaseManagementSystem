using Application.Dto_s;
using CaseManagementSystemAPI.ResponseHandlers;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementSystemAPI.ResponseHelpers.LawyerControllerResponseHelper
{
    public class GetLawyerPrimaryDataByIdResponseHelper
    {
        public static IActionResult Map(LawyerReadDto? result)
        {
            return result is not null
                ? new OkObjectResult(
                    new APIResponseHandler<LawyerReadDto>(
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
