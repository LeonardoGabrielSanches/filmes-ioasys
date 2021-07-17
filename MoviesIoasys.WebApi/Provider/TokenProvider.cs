using Microsoft.IdentityModel.Tokens;
using MoviesIoasys.Domain.Entities;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace MoviesIoasys.WebApi.Provider
{
    public class TokenProvider
    {
        public static string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("d41d8cd98f00b204e9800998ecf8427e"); // Retirar o código fixo
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                   new Claim(
                       ClaimTypes.NameIdentifier,
                       user.Id.ToString()),
                    new Claim(
                        ClaimTypes.Email,
                        user.Email),
                    new Claim(
                        ClaimTypes.Role,
                        user.UserRole.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public static string GetEmailFromToken(ClaimsPrincipal User)
            => User.Identities.FirstOrDefault().Claims.FirstOrDefault(y => y.Type == ClaimTypes.Email).Value;

        public static string GetIdFromToken(ClaimsPrincipal User)
            => User.Identities.FirstOrDefault().Claims.FirstOrDefault(y => y.Type == ClaimTypes.NameIdentifier).Value;
    }
}
