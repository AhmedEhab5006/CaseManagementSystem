using Application.Commons;
using Application.Dto_s.Audting;
using CaseManagementSystemAPI.ResponseHandlers;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementSystemAPI.ResponseHelpers.CaseControllerResponses
{
    public class GetCaseHistoryResponseHelper
    {
        public static IActionResult Map(PagedResult<CaseHistoryReadDto> result)
        {
            if (result == null || result.Data == null || !result.Data.Any())
            {
                return new OkObjectResult(
                    new APIResponseHandler<string>(
                        200,
                        "No Data",
                        data: "لا توجد سجلات تاريخية لهذه القضية"
                    )
                );
            }

            return new OkObjectResult(
                new APIResponseHandler<PagedResult<CaseHistoryReadDto>>(
                    200,
                    "Success",
                    data: result
                )
            );
        }
    }
}
