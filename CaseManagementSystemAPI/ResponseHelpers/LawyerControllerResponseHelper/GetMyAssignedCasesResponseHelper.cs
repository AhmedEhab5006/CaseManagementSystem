using Application.Commons;
using Application.Dto_s.CaseDtos;
using CaseManagementSystemAPI.ResponseHandlers;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementSystemAPI.ResponseHelpers.LawyerControllerResponseHelper
{
    public class GetMyAssignedCasesResponseHelper
    {
        public static IActionResult Map(PagedResult<CaseReadDto> result)
        {
            return result switch
            {
                not null when result.Data != null && result.Data.Any()
                    => new OkObjectResult(
                        new APIResponseHandler<PagedResult<CaseReadDto>>(
                            200,
                            "Success",
                            data: result
                        )
                    ),

                _ => new NotFoundObjectResult(
                        new APIResponseHandler<string>(
                            404,
                            "Not Found",
                            data: "No Assigned Cases Found | لا توجد قضايا موكلة لهذا المحامي"
                        )
                    )
            };
        }
    }
}
