using CaseManagementSystemAPI.ResponseHandlers;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementSystemAPI.ResponseHelpers.LawyerControllerResponseHelper
{
    public class SendCaseReAssignmentRequestResponseHelper
    {
        public static IActionResult Map(CaseReAssignmentValidation result)
        {
            return result switch
            {
                CaseReAssignmentValidation.Done => new OkObjectResult(
                    new APIResponseHandler<string>(
                        200, "Success",
                        data: "Case reassignment request sent successfully | تم إرسال طلب إعادة إسناد القضية بنجاح")
                ),

                CaseReAssignmentValidation.AssigneeNotFound => new NotFoundObjectResult(
                    new APIResponseHandler<string>(
                        404, "Not Found",
                        data: "Desired assignee wasn't found | المستخدم المطلوب غير موجود")
                ),

                CaseReAssignmentValidation.AssigneeAlreadyExists => new BadRequestObjectResult(
                    new APIResponseHandler<string>(
                        400, "Bad Request",
                        data: "Assignee is already assigned to this case | المستخدم مكلف بالفعل بهذه القضية")
                ),

                CaseReAssignmentValidation.CaseNotFound => new NotFoundObjectResult(
                    new APIResponseHandler<string>(
                        404, "Not Found",
                        data: "Desired case wasn't found | القضية المطلوبة غير موجودة")
                ),

                CaseReAssignmentValidation.Error => new BadRequestObjectResult(
                    new APIResponseHandler<string>(
                        400, "Bad Request",
                        data: "An error occurred | حدث خطأ ما")
                ),
                CaseReAssignmentValidation.ArenotAssignedToCase => new BadRequestObjectResult(
               new APIResponseHandler<string>(
                   400, "Bad Request",
                   data: "You Aren't Assigned To this case so You Can't send Re-Assignment Request " +
                   "| انت غير مسند لهذه الدعوى لذلك لا يمكنك ارسال طلب اعادة اسناد")
               {

               }),


                _ => new BadRequestObjectResult(
                    new APIResponseHandler<string>(
                        400, "Bad Request",
                        data: "Unexpected result | نتيجة غير متوقعة")
                )
            };
        }
    }
}

