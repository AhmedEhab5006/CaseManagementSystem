using Application.Dto_s;
using Application.Enums;
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

                }



                var token = GenerateToken(claims);

                return token;

            }

            return LoginValidation.UserNotFound.ToString();
        }

        public string GenerateToken(IList<Claim> claims)
        {

            RSA rsa = RSA.Create(2048); // توليد مفتاح RSA داخلي 2048 bit
            var securityKey = new RsaSecurityKey(rsa);
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.RsaSha256);

            var expiryDate = DateTime.UtcNow.AddMinutes(15);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expiryDate,
                signingCredentials: signingCredentials
            );

            var handler = new JwtSecurityTokenHandler();
            var token = handler.WriteToken(jwtSecurityToken);

            return token;
        }
    }
    }
