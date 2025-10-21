using Application.Commons;
using Application.Dto_s.CaseDtos;
using CaseManagementSystemAPI.ResponseHandlers;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementSystemAPI.ResponseHelpers.CaseControllerResponses
{
    public class CasePrimaryDataResponseHelper
    {
 
            public static IActionResult Map(PagedResult<CaseReadDto> records)
            {
                if (records is not null && records.TotalRecords > 0)
                {
                    return new OkObjectResult(
                        new APIResponseHandler<PagedResult<CaseReadDto>>(
                            200,
                            "Success",
                            data: records
                        )
                    );
                }

                return new NotFoundObjectResult(
                    new APIResponseHandler<string>(
                        404,
                        "Not Found",
                        data: "There is No Data to Show | لا يوجد بيانات لعرضها"
                    )
                );
            }
        }
    }

