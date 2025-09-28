using Application.Dto_s;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Auth
{
    public class SendOTPUseCase(IEmailService _emailService)
    {

        public async Task Execute(EmailSendDto email)
        {
            int otp = new Random().Next(100000, 999999);

            try
            {
                await _emailService.SendEmailAsync(email.email, otp);
            }


            catch (Exception ex) {
                throw new EmailSendingFailureUseCase("Failed to send verification email. Please try again later " +
                    "this maybe casued due to bad internet conncetion or something | فشل في ارسال بريد التحقق ممكن ان يتم التسبب في ذلك بسبب اتصال سئ بالانترت او شئ اخر");

            }
        }
    }
}
