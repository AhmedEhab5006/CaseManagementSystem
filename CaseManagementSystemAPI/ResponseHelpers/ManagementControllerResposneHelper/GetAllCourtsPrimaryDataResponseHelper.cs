using Application.Commons;
using Application.Dto_s.CourtDto_s;
using CaseManagementSystemAPI.ResponseHandlers;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementSystemAPI.ResponseHelpers.ManagementControllerResposneHelper
{
    public class GetAllCourtsPrimaryDataResponseHelper
    {
        public static IActionResult Map(PagedResult<CourtPrimaryDataReadDto> result)
        {
            return result switch
            {
                not null => new OkObjectResult(
                    new APIResponseHandler<PagedResult<CourtPrimaryDataReadDto>>(
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

