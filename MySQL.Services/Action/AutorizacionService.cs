using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using MySQL.DataAccess.Models;
using MySQL.DataAccess.Models.Custom;
using MySQL.Services.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System;
using Microsoft.EntityFrameworkCore;

namespace MySQL.Services.Action
{
    public class AutorizacionService : IAutorizacionService
    {
        private readonly ProyectoContext   _context;
        private readonly IConfiguration _configuration;

        public AutorizacionService(ProyectoContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        private string GenerarToken(string idUsuario)
        {
            var key = _configuration.GetSection("settings:secretkey").ToString();
            var keyBytes = Encoding.ASCII.GetBytes(key);

            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, idUsuario));

            var credencialToken = new SigningCredentials(
                new SymmetricSecurityKey(keyBytes),
                SecurityAlgorithms.HmacSha256Signature
                );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = credencialToken
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

            string tokenCreado = tokenHandler.WriteToken(tokenConfig);

            return tokenCreado;
        }


        public async Task<AutorizacionResponse> DevolverToken(AutorizacionRequest autorizacion)
        {
            var coincide = _context.Usuarios.FirstOrDefault(x => x.Usuario1 == autorizacion.NombreUsuario && x.Clave == autorizacion.clave);

            if (coincide == null)
            {
                return await Task.FromResult<AutorizacionResponse>(null);
            }

            string tokenCreado = GenerarToken(coincide.IdUsuario.ToString());
            return new AutorizacionResponse()
            {
                Token = tokenCreado,
                Resultado = true,
                Mensaje = "OK"
            };

        }
    }
}
