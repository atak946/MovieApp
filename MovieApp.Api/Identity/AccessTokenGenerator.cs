using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MovieApp.Application.Dtos;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MovieApp.Api.Identity
{
    public class AccessTokenGenerator
    {
        private readonly IConfiguration _config;
        private readonly IdentityUser _applicationUser;

        public AccessTokenGenerator(IConfiguration config, IdentityUser identityUser)
        {
            _config = config;
            _applicationUser = identityUser;
        }

        public IdentityUserTokenDto GenerateToken()
        {
            DateTime expireDate = DateTime.Now.AddDays(60);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Application:Secret"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _config["Application:Audience"],
                Issuer = _config["Application:Issuer"],
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, _applicationUser.Id),
                    new Claim(ClaimTypes.Name, _applicationUser.UserName),
                    new Claim(ClaimTypes.Email, _applicationUser.Email)
                }),

                Expires = expireDate,

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            IdentityUserTokenDto tokenInfo = new();

            tokenInfo.Token = tokenString;
            tokenInfo.ExpireDate = expireDate;

            return tokenInfo;
        }
    }
}
