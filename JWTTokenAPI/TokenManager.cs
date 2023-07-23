using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace JWTTokenAPI
{
    public class TokenManager
    {
        private static string Secret = "MjUxQjRFN0UtNUM4Mi00MDI4LUE0MUEtMkQwMDUzMjhGMDQ0"; //Guid.NewGuid().ToString();   //GUID: Creates a unique identifier

        public static string GenerateToken(string userName)
        {
            byte[] key = Convert.FromBase64String(Secret);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims: new[] { new Claim(type: ClaimTypes.Name, userName) }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(securityKey, algorithm: SecurityAlgorithms.HmacSha256Signature)
                               
            };
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(tokenDescriptor);

            return handler.WriteToken(token);
        }
    }
}