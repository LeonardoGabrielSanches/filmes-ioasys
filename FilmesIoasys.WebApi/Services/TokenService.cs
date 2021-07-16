using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FilmesIoasys.Dominio.Entidades;
using Microsoft.IdentityModel.Tokens;

namespace FilmesIoasys.WebApi.Services
{
    public static class TokenService
    {
        public static string GeraTokem(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var chave = Encoding.ASCII.GetBytes("d41d8cd98f00b204e9800998ecf8427e"); // Retirar o código fixo
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                   new Claim(
                       ClaimTypes.NameIdentifier,
                       usuario.Id.ToString()),
                    new Claim(
                        ClaimTypes.Role,
                        usuario.TipoUsuario.ToString("d")
                    )
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(chave),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}