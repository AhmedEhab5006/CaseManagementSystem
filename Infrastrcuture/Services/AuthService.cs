using Application.UseCases.Auth;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.Services
{
    public class AuthService(IHttpContextAccessor _httpContextAccessor) : IAuthService

    {
        public string GetLoggedId()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            var id = user.FindFirst("Id")?.Value.ToString();

            return id;
        }

        public string GetLoggedUserName()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            var id = user.FindFirst("Username")?.Value.ToString();

            return id;
        }
    }
}
