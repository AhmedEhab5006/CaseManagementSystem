using Application.UseCases.Auth;
using Application.UseCases.Exceptions;
using System.Net;
using System.Text.Json;

namespace CaseManagementSystemAPI.Middlewares
{
    public class GlobalExceptionHandler(RequestDelegate _next)
    {

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); // continue pipeline
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            int statusCode;
            string message;

            switch (exception)
            {
                case EmailSendingFailureUseCase:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    message = "Failed to send verification email. Please try again later " +
                        "this maybe casued due to bad internet conncetion or something | فشل في ارسال بريد التحقق ممكن ان يتم التسبب في ذلك بسبب اتصال سئ بالانترت او شئ اخر";
                    break;

                case LitigantAlreadyExixstException:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    message = "This Litigant Already Exist at this Case | هذا الطرف موجود في هذه الدعوى بالفعل";
                    break;



                case KeyNotFoundException:
                    statusCode = (int)HttpStatusCode.NotFound;
                    message = "The requested resource was not found.";
                    break;

                case UnauthorizedAccessException:
                    statusCode = (int)HttpStatusCode.Unauthorized;
                    message = "You are not authorized to perform this action.";
                    break;

                default:
                    statusCode = (int)HttpStatusCode.InternalServerError;
                    message = exception.Message;
                    break;
            }

            response.StatusCode = statusCode;

            var result = JsonSerializer.Serialize(new
            {
                statusCode,
                message
            });

            return response.WriteAsync(result);
        }
    }
}
