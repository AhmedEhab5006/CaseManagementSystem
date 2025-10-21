using CaseManagementSystemAPI.ResponseHandlers;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementSystemAPI.ResponseHelpers.FileControllerResponseHelper
{
    public class UploadFileResponseHelper
    {
        public static IActionResult Map(IEnumerable<Guid>? uploadedFileIds)
        {
            return uploadedFileIds is not null && uploadedFileIds.Any()
                ? new OkObjectResult(
                    new APIResponseHandler<object>(
                        200,
                        "Success",
                        data: new
                        {
                            Message = "Files uploaded successfully | تم رفع الملفات بنجاح",
                            FileIds = uploadedFileIds
                        }
                    )
                  )
                : new BadRequestObjectResult(
                    new APIResponseHandler<string>(
                        400,
                        "Bad Request",
                        data: "No files provided for upload | لم يتم تقديم أي ملفات للرفع"
                    )
                  );
        }
    }
}
