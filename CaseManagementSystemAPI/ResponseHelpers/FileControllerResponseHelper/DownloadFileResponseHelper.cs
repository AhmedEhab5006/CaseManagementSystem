using Application.Dto_s.File;
using CaseManagementSystemAPI.ResponseHandlers;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementSystemAPI.ResponseHelpers.FileControllerResponseHelper
{
    public class DownloadFileResponseHelper
    {
        public static IActionResult Map(FileReadDto? result)
        {
            return result is not null
                ? new FileContentResult(result.data, "application/octet-stream")
                {
                    FileDownloadName = result.Name
                }
                : new BadRequestObjectResult(
                    new APIResponseHandler<string>(
                        404,
                        "Not Found",
                        data: "File Wasn't Found | لم يتم العثور على الملف"
                    )
                  );
        }

    }
}
