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
using System.Security.Cryptography;

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


        private string GenerarRefreshToken()
        {
            var byteArray = new byte[64];
            var refreshToken = "";

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(byteArray);
                refreshToken = Convert.ToBase64String(byteArray);
            }
            return refreshToken;
        }


        private async Task<AutorizacionResponse>GuardarHistorialRefreshToken(int idUsuario, string token, string refreshToken)
        {
            var historialRefreshToken = new HitorialRefreshToken
            {
                IdUsuario = idUsuario,
                Token = token,
                RefreshToken = refreshToken,
                FechaCreacion = DateTime.UtcNow,
                FechaExpiracion = DateTime.UtcNow.AddHours(8)
            };

            await _context.HitorialRefreshTokens.AddAsync(historialRefreshToken);
            await _context.SaveChangesAsync();

            return new AutorizacionResponse() { Token = token, RefreshToken = refreshToken, Resultado = true, Mensaje = "OK" };
        }


        public async Task<AutorizacionResponse> DevolverToken(AutorizacionRequest autorizacion)
        {
            var coincide = _context.Usuarios.FirstOrDefault(x => x.Usuario1 == autorizacion.NombreUsuario && x.Clave == autorizacion.clave);

            if (coincide == null)
            {
                return await Task.FromResult<AutorizacionResponse>(null);
            }

            string tokenCreado = GenerarToken(coincide.IdUsuario.ToString());
            string refreshTokenCreado = GenerarRefreshToken();
            /*return new AutorizacionResponse()
            {
                Token = tokenCreado,
                Resultado = true,
                Mensaje = "OK"
            };*/

            return await GuardarHistorialRefreshToken(coincide.IdUsuario, tokenCreado, refreshTokenCreado);

        }

        public async Task<AutorizacionResponse> DevolverRefreshToken(RefreshTokenRequest refreshTokenRequest, int idUsuario)
        {
            var refreshTokenEncontrado = _context.HitorialRefreshTokens.FirstOrDefault(x => 
            x.Token == refreshTokenRequest.TokenExpirado &&
            x.RefreshToken == refreshTokenRequest.RefreshToken &&
            x.IdUsuario == idUsuario);

            if (refreshTokenEncontrado == null)
                return new AutorizacionResponse { Resultado = false, Mensaje = "No existe refreshToken" };

            var refreshTokenCreado = GenerarRefreshToken();
            var tokenCreado = GenerarToken(idUsuario.ToString());

            return await GuardarHistorialRefreshToken(idUsuario, tokenCreado, refreshTokenCreado);
        }
    }
}
