using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LMSCapstone.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace LMSCapstone.Helpers
{
    public interface IJWTManager
    {
         string GenerateToken(User user);
    }

    public class JWTManager : IJWTManager
    {
         private readonly IConfiguration _configuration;
         public JWTManager(IConfiguration configuration)
         {
             _configuration = configuration;
         }
         public string GenerateToken(User user)
         {
             var tokenHandler = new JwtSecurityTokenHandler();
             var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
             var tokenDescriptor = new SecurityTokenDescriptor
             {
                 Subject = new ClaimsIdentity(new Claim[]
                 {
                     new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                     new Claim(ClaimTypes.Email, user.Email),
                     new Claim(ClaimTypes.Role, user.Role.ToString())
                 }),
                 Expires = DateTime.UtcNow.AddHours(1),
                 SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
             };
             var token = tokenHandler.CreateToken(tokenDescriptor);
             return tokenHandler.WriteToken(token);
         }
    }
}
