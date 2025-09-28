using Application.Dto_s;
using Application.Enums;
using Application.UseCases.Auth;
using CaseManagementSystemAPI.ResponseHandlers;
using Infrastrcuture.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(SendOTPUseCase _sendOtpUseCase, VerifyOTPUseCase _verifyOTPUseCase , CheckEmail _checkEmail , ILoginService _loginService) : ControllerBase
    {

        [HttpPost("Send-Verification-Email")]
        public async Task<IActionResult> SendOtp(EmailSendDto email)
        {

            var check = await _checkEmail.Execute(email);
            if (check)
            {
                await _sendOtpUseCase.Execute(email);
                return Ok(new APIResponseHandler<string>(200, "Success", data: "OTP was sent | تم أرسال كلمة السر المؤقتة"));

            }

            else
            {
                return NotFound(new APIResponseHandler<string>(404, "Not Found", data: "Desired Email Wasn't found try another one | البريد الالكتروني المطلوب غير موجود جرب ادخال بريد اخر"));
            }

        }

        [HttpPost("Verify-Email")]
        public async Task<IActionResult> VerifyOTP(VerfiyOTPDto verfiyOTPDto)
        {
           if (_verifyOTPUseCase.Execute(verfiyOTPDto.Otp))
            {
                return Ok(new APIResponseHandler<string>(200, "Success", data: "You were verified | تم اثبات هويتك"));
            };

            return BadRequest(new APIResponseHandler<string>(400, "BadRequest", data: "Entered OTP was wrong (Failed to Verify) | كلمة سر مؤقتة خاطئة لم يتم اثبات الهوية"));

        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login (LoginDto login)
        {
            var logged = await _loginService.Login(login);

            if (logged == LoginValidation.WrongUsername.ToString())
            {
                return BadRequest(new APIResponseHandler<string>(400, "BadRequest", data: "Wrong Username | اسم مستخدم خاطئ"));

            }

            if (logged == LoginValidation.WrongPassword.ToString())
            {
                return BadRequest(new APIResponseHandler<string>(400, "BadRequest", data: "Wrong Password | كلمة سر خاطئة"));

            }


            if (logged == LoginValidation.UserNotFound.ToString())
            {
                return BadRequest(new APIResponseHandler<string>(404, "Not Found", data: "User Wasn't Found | المستخدم غير موجود"));

            }

            return Ok(new APIResponseHandler<string>(200, "Success", data: logged));

        }
    }
}
