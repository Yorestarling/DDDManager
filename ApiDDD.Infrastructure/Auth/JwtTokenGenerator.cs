using ApiDDD.Application.Common.Interfaces.Auth;
using ApiDDD.Application.Common.Interfaces.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace ApiDDD.Infrastructure.Auth
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IDateTimeProvider _dataTimeProvider;
        private readonly  JwtSettings _jwtSettings;
        public JwtTokenGenerator(IDateTimeProvider dataTimeProvider, IOptions<JwtSettings> jwtSettings)
        {
            _dataTimeProvider = dataTimeProvider;
            _jwtSettings = jwtSettings.Value;
        }

        public string GenerateToken(Guid userId, string firstName, string lastName)
        {

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey (Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                SecurityAlgorithms.HmacSha256);
            
            
            
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, firstName),
                new Claim(JwtRegisteredClaimNames.FamilyName,lastName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            };

            var securityToken = new JwtSecurityToken(
                issuer:_jwtSettings.Issuer,
                audience:_jwtSettings.Audience,
                expires: _dataTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpirationTimeInMinutes),
                claims: claims,
                signingCredentials: signingCredentials);
        
        return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
