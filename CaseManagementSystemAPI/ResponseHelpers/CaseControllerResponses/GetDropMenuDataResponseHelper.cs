using Application.Dto_s.CaseDtos;
using CaseManagementSystemAPI.ResponseHandlers;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementSystemAPI.ResponseHelpers.CaseControllerResponses
{
    public class GetDropMenuDataResponseHelper
    {
        public static IActionResult Map(IEnumerable<CaseDropDownMenuGetDto>? result)
        {
            return result is not null
                ? new OkObjectResult(
                    new APIResponseHandler<IEnumerable<CaseDropDownMenuGetDto>>(
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
