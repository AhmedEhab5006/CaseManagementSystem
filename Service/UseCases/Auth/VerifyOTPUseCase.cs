using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Auth
{
    public class VerifyOTPUseCase
    {
        private readonly IOTPCache _otpCache;

        public VerifyOTPUseCase(IOTPCache otpCache)
        {
            _otpCache = otpCache;
        }

        public bool Execute(string enteredOtp)
        {
            var cachedOtp = _otpCache.Get("OTP");
            return cachedOtp != null && cachedOtp == enteredOtp;
        }
    }
}
