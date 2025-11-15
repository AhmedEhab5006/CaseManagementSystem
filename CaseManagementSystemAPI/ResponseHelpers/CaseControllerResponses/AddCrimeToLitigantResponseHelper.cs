using CaseManagementSystemAPI.ResponseHandlers;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementSystemAPI.ResponseHelpers.CaseControllerResponses
{
    public class AddCrimeToLitigantResponseHelper
    {
        public static IActionResult Map(AddCrimeValidations result)
        {
            return result switch
            {
                AddCrimeValidations.Added => new OkObjectResult(
                    new APIResponseHandler<string>(
                        200, "Success",
                        data: "Crime successfully added to litigant | تم إضافة الجريمة للطرف بنجاح")
                ),

                AddCrimeValidations.CaseNotFound => new BadRequestObjectResult(
                    new APIResponseHandler<string>(
                        400, "Bad Request",
                        data: "Desired case wasn't found | القضية المطلوبة غير موجودة")
                ),

                AddCrimeValidations.LitigantNotFound => new BadRequestObjectResult(
                    new APIResponseHandler<string>(
                        400, "Bad Request",
                        data: "Desired litigant wasn't found | الطرف المطلوب غير موجود")
                ),

                AddCrimeValidations.CrimeNotFound => new BadRequestObjectResult(
                    new APIResponseHandler<string>(
                        400, "Bad Request",
                        data: "Desired crime wasn't found | الجريمة المطلوبة غير موجودة")
                ),

                AddCrimeValidations.PenaltyNotFound => new BadRequestObjectResult(
                    new APIResponseHandler<string>(
                        400, "Bad Request",
                        data: "Desired penalty wasn't found | العقوبة المطلوبة غير موجودة")
                ),

                AddCrimeValidations.CrimeAlreadyAdded => new BadRequestObjectResult(
                    new APIResponseHandler<string>(
                        400, "Bad Request",
                        data: "This Crime Is Already Added to This Litigant | تمت اضافة هذه الجريمة للمتهم من قبل")
                ),

                AddCrimeValidations.PenaltyAlreadyAdded => new BadRequestObjectResult(
                    new APIResponseHandler<string>(
                        400, "Bad Request",
                        data: "This Penalty Is Already Added to This Litigant | تمت اضافة هذه العقوبة للمتهم من قبل")
                ),

                AddCrimeValidations.Error => new BadRequestObjectResult(
                    new APIResponseHandler<string>(
                        400, "Bad Request",
                        data: "An error occurred | حدث خطأ ما")
                ),

                _ => new BadRequestObjectResult(
                    new APIResponseHandler<string>(
                        400, "Bad Request",
                        data: "Unexpected result | نتيجة غير متوقعة")
                )
            };
        }
    }
}
