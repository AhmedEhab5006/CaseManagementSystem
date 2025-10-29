using Application.Dto_s.AccountDto_s;
using CaseManagementSystemAPI.ResponseHandlers;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementSystemAPI.ResponseHelpers.AccountControllerResponseHelper
{
    public class GetAccountDataResponseHelper
    {
        public static IActionResult Map(AccountReadDto result)
        {
            return result switch
            {
                 not null => new OkObjectResult(
                    new APIResponseHandler<AccountReadDto>(
                        200, "Success",
                        data: result)
                ),

                null => new NotFoundObjectResult(
                   new APIResponseHandler<string>(
                       404, "NotFound",
                       data: "Desired Account Wasn't Found | الحساب المطلوب غير موجود")
                )

            };
        }
    }
}
