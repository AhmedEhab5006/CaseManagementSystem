using CaseManagementSystemAPI.ResponseHandlers;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementSystemAPI.ResponseHelpers.CaseControllerResponses
{
    public class CaseTopicAddResponseHelper
    {
        public static IActionResult Map(bool result)
        {
            return result switch
            {
                true => new OkObjectResult(
                    new APIResponseHandler<string>(
                        200, "Success",
                        data: "Case Topic Was Sucssefully Added | تمت اضافة موضوع القضية بنجاح")
                ),


               _ => new BadRequestObjectResult(
                    new APIResponseHandler<string>(
                        400, "Bad Request",
                        data: "An Error Occurred | حدث خطأ ما")
                )
            };
        }

    }
}

