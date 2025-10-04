using Application.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IResetPasswordService
    {
        public Task<bool> ResetPasswordAsync(ApplicationUserReadDto user, string token , string newPassword);
        public Task<string> GenerateResetPassowrdTokenAsync();


    }
}
