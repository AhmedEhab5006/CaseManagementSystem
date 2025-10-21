using CaseManagementSystemAPI.ResponseHandlers;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementSystemAPI.ResponseHelpers.CaseControllerResponses
{
    public class CaseDocumentAddResponseHelper
    {
        public static IActionResult Map(CaseDocumentAddValidation result)
        {
            return result switch
            {
                CaseDocumentAddValidation.Added => new OkObjectResult(
                    new APIResponseHandler<string>(200, "تمت إضافة الملف بنجاح | File Was Sucssefully Added")
                ),

                CaseDocumentAddValidation.CaseWasnotFound => new BadRequestObjectResult(
                    new APIResponseHandler<string>(400 , "لم يتم العثور على الدعوى | Case Wasn't Found")
                ),

                CaseDocumentAddValidation.FileWasnotFound => new BadRequestObjectResult(
                    new APIResponseHandler<string>(400 , "الملف غير موجود | File Doesn't Exist")
                ),

                CaseDocumentAddValidation.DocumentTypeWasnotFound => new BadRequestObjectResult(
                    new APIResponseHandler<string>(400 , "نوع المستند غير موجود | Document Wasn't Found")
                ),

                CaseDocumentAddValidation.Error => new BadRequestObjectResult(
                    new APIResponseHandler<string>(400, "حدث خطأ أثناء إضافة الملف | Error Happened While Adding The File")
                ),

                _ => new BadRequestObjectResult(
                    new APIResponseHandler<string>(400, "خطأ غير معروف | UnKnown Error")
                )
            };
        }
    }
}
