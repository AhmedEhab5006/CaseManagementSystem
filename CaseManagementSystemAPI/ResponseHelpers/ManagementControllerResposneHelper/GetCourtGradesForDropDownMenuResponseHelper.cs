using Application.Dto_s.CaseDtos;
using CaseManagementSystemAPI.ResponseHandlers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CaseManagementSystemAPI.ResponseHelpers.ManagementControllerResposneHelper
{
    public class GetCourtGradesForDropDownMenuResponseHelper
    {
        public static IActionResult Map(IEnumerable<CaseDropDownMenuGetDto> result)
        {
            return result switch
            {
                not null => new OkObjectResult(
                    new APIResponseHandler<IEnumerable<CaseDropDownMenuGetDto>>(
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

