using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.BusinessLogicModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebApi.DTOs;

namespace WebApi.JWT
{
    public class JwtService : IJwtService
    {
        private IConfiguration _configuration;
        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string CreateTokenAsync(Account user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(CreateClaims(user)),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var accessToken = tokenHandler.CreateToken(tokenDescriptor);
            string tokenString = tokenHandler.WriteToken(accessToken);

            return tokenString;
        }
        private IEnumerable<Claim> CreateClaims(Account user)
        {
            var userIdClaim = new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString());
            var userRoleClaim = new Claim(ClaimTypes.Role, user.Role.ToString());

            return new[] { userIdClaim, userRoleClaim };
        }
    }
}