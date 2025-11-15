using CaseManagementSystemAPI.ResponseHandlers;
using Microsoft.AspNetCore.Mvc;
using Application.Commons;
using Application.Dto_s.CaseDtos;
using System.Collections.Generic;

namespace CaseManagementSystemAPI.ResponseHelpers.CaseControllerResponses
{
    public static class GetCrimesByLitigantResponseHelper
    {
        public static IActionResult Map(PagedResult<CrimeReadDto> result)
        {
            if (result == null || result.Data == null)
            {
                return new BadRequestObjectResult(
                    new APIResponseHandler<string>(
                        400, "Bad Request",
                        data: "No crimes found for the given litigant | لا توجد جرائم للطرف المحدد"
                    )
                );
            }

            return new OkObjectResult(
                new APIResponseHandler<PagedResult<CrimeReadDto>>(
                    200, "Success",
                    data: result
                )
            );
        }
    }
}
