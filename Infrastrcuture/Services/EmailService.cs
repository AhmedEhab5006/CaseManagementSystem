using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Application.Dto_s;
using Microsoft.Extensions.Caching.Memory;
using static System.Net.WebRequestMethods;

namespace Infrastrcuture.Services
{
    public class EmailService : IEmailService
    {
        private IConfiguration _configuration;
        private ICacheService _cache;

        public EmailService(IConfiguration configuration , ICacheService cache)
        {
            _configuration = configuration;
            _cache = cache;
        }

        public async Task SendOTPAsync(string email, int otp)
        {
            var smtpSettings = _configuration.GetSection("SmtpSettings");

            using (var client = new SmtpClient(smtpSettings["Host"], int.Parse(smtpSettings["Port"])))
            {
                client.Credentials = new NetworkCredential(smtpSettings["UserName"], smtpSettings["Password"]);
                client.EnableSsl = bool.Parse(smtpSettings["EnableSsl"]);

                var helwanLogo = "CaseManagementSystem\\Domain\\Assets\\helwan-logo.png";
                var lang = "ar";
                var direction = "rtl";

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(smtpSettings["UserName"]),
                    Subject = "من فضلك قم بأثبات هويتك | Please Verfiy Your Identity",
                    Body = $@"
      <div style='font-family: Arial, sans-serif; font-size: 14px; color: #333;'>
            <p>كلمة السر المؤقتة الخاصة بك هي: <strong style='color: #d9534f;'>{otp}</strong></p>
            <p>احتفظ بها ولا تقم بمشاركتها مع أحد.</p>
            <hr/>
            <p>Your OTP is: <strong style='color: #d9534f;'>{otp}</strong><br/>
            Just keep it to yourself and don't send it to anyone.</p>
        </div>
",
                    IsBodyHtml = true
                };

                mailMessage.To.Add(email);
                await client.SendMailAsync(mailMessage);

                _cache.Set("OTP", otp.ToString(), TimeSpan.FromMinutes(1));
                _cache.Set("email", email, TimeSpan.FromMinutes(15));

            }
        }

    }
}