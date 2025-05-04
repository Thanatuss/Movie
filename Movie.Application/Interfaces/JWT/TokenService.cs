using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Movie.Domain.Entities;

namespace Movie.Application.Interfaces.JWT
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;

        public TokenService(IConfiguration config)
        {
            _config = config;
        }

        public string CreateToken(User user)
        {
            var Claims = new[]
            {
                new Claim(ClaimTypes.Name , user.Fullname),
                new Claim(ClaimTypes.NameIdentifier , user.Id.ToString())


            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                        issuer: _config["Jwt:Issuer"],
                        audience: _config["Jwt:Audience"],
                        claims: Claims,
                        expires: DateTime.Now.AddHours(2),
                        signingCredentials: creds
                    );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
