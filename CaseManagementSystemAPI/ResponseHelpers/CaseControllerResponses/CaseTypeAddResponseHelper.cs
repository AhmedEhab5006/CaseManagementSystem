using CaseManagementSystemAPI.ResponseHandlers;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementSystemAPI.ResponseHelpers.CaseControllerResponses
{
    public class CaseTypeAddResponseHelper
    {
        public static IActionResult Map(bool result)
        {
            return result switch
            {
                true => new OkObjectResult(
                   new APIResponseHandler<string>(200, "Success",
                    data: "Case Type Was Sucssefully Added | تمت اضافة نوع القضية بنجاح")),


                _ => new BadRequestObjectResult(
                     new APIResponseHandler<string>(
                         400, "Bad Request",
                         data: "An Error Occurred | حدث خطأ ما")
                 )
            };
        }
    }
}
