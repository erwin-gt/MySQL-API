using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySQL.DTO;
using MySQL.Services.Interface;
using MySQL_API.Mappings.Notas;
using MySQL_API.Mappings;
using Newtonsoft.Json;
using MySQL.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using MySQL.DataAccess.Models.Custom;

namespace MySQL_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _servicio;
        private readonly IAutorizacionService _autorizacionService;

        public UsuarioController(IUsuarioService servicio, IAutorizacionService autorizacionService)
        {
            _servicio = servicio;
            _autorizacionService = autorizacionService;
        }


        //Autenticacion del Usuario

        [HttpPost]
        [Route("Autenticar")]
        public async Task<IActionResult> Autenticar([FromBody] AutorizacionRequest autorizacion)
        {
            var resultadoAutorizacion = await _autorizacionService.DevolverToken(autorizacion);
            if(resultadoAutorizacion == null)
                return Unauthorized();
            return Ok(resultadoAutorizacion);
        }

        [HttpPost]
        [Route("ObtenerRefreshToken")]
        public async Task<IActionResult> ObtenerRefreshToken([FromBody] RefreshTokenRequest request)
        {
            var tokenHadler = new JwtSecurityTokenHandler();
            var tokenExpirado = tokenHadler.ReadJwtToken(request.TokenExpirado);

            if (tokenExpirado.ValidTo > DateTime.UtcNow)
                return BadRequest(new AutorizacionResponse { Resultado = false, Mensaje = "Token no ha Expirado" });

            string idUsuario = tokenExpirado.Claims.First(x =>
            x.Type == JwtRegisteredClaimNames.NameId).Value.ToString();

            var autorizacionResponse = await _autorizacionService.DevolverRefreshToken(request, int.Parse(idUsuario));

            if (autorizacionResponse.Resultado)
                return Ok(autorizacionResponse);
            else
                return BadRequest(autorizacionResponse);

        }



        //Lista la informacion de Usuario
        [HttpGet]
        public async Task<ActionResult<List<UsuarioDTO>>> Listar()
        {
            //utilizado por el servicio creado IUsuarioService
            var retorno = await _servicio.Listar();

            //Validacion del Servicio
            if (retorno.Objeto != null)
                return retorno.Objeto.Select(MapperUser.ToDTO).ToList();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        //Lista la informacion de Usuario segun el ID ingresado
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO>> BuscarPorId(int id)
        {
            var retorno = await _servicio.BuscarPorId(id);
            //Validacion del Servicio
            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        

        //Actualizacion de Datos
        [HttpPut]
        public async Task<ActionResult<UsuarioDTO>> Actualizar(UsuarioDTO nt)
        {
            var retorno = await _servicio.Actualizar(nt.ToDatabase());
            //Validacion del Servicio
            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        //Eliminacion de Usuario segun ID ingresado
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Elimiar(int id)
        {
            var retorno = await _servicio.Eliminar(id);
            //Validacion del Servicio
            if (retorno.Exito)
                return true;
            else
                return StatusCode(retorno.Status, retorno.Error);
        }
    }
}
