using Application.Commons;
using Application.Dto_s.CaseDtos;
using CaseManagementSystemAPI.ResponseHandlers;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementSystemAPI.ResponseHelpers.CaseControllerResponses
{
    public class GetCaseLitigantsPrimaryDataResponseHelper
    {
        public static IActionResult Map(PagedResult<LitigantReadDto>? result)
        {
            return result is not null
                ? new OkObjectResult(
                    new APIResponseHandler<PagedResult<LitigantReadDto>>(
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
