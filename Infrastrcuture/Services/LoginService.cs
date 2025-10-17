using Application.Dto_s;
using Application.Enums;
using Application.Interfaces;
using Application.Repositories.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.Services
{
    public class LoginService(IAuthRepository _userRepository , IConfiguration _configuration) : ILoginService
    {

        // RSA key will be injected from Program.cs

        public async Task<string> Login(LoginDto loginDto)
        {
            var found = await _userRepository.FindByUsernameAsync(loginDto.username);

            if (found is not null)
            {
                if (!await _userRepository.CheckUsernameAsync(loginDto.username))
                {
                    return LoginValidation.WrongUsername.ToString();
                }

                if (!await _userRepository.CheckPasswordAsync(loginDto.password, found))
                {
                    return LoginValidation.WrongPassword.ToString();
                }

                var role = await _userRepository.GetUserRoleAsync(found);


                var claims = await _userRepository.GetClaimsAsync(found);
                
                if (claims is null)
                {
                    await _userRepository.AddClaimsAsync(found, new Claim("Id", found.Id.ToString()));
                    await _userRepository.AddClaimsAsync(found, new Claim("Username", found.UserName));
                    await _userRepository.AddClaimsAsync(found, new Claim("Email", found.Email));
                    await _userRepository.AddClaimsAsync(found, new Claim("Role", role.FirstOrDefault().ToString()));

                    // Get the updated claims after adding them
                    claims = await _userRepository.GetClaimsAsync(found);
                }

                var token = GenerateToken(claims);

                return token;

            }

            return LoginValidation.UserNotFound.ToString();
        }

        public string GenerateToken(IList<Claim> claims)
        {

            var privateKeyText = File.ReadAllText("Security/private_key.pem");

            // لا تستخدم using هنا
            var rsa = RSA.Create(2048);
            rsa.ImportFromPem(privateKeyText);

            var key = new RsaSecurityKey(rsa);
            var creds = new SigningCredentials(key, SecurityAlgorithms.RsaSha256);

            var token = new JwtSecurityToken(
                issuer: "myapp",
                audience: "myapp_users",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(15),
                signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }

    }
