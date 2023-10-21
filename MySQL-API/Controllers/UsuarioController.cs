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


        /*
        private readonly ProyectoContext _context;
        public IConfiguration _configuration;

        public UsuarioController(IUsuarioService servicio, ProyectoContext context, IConfiguration configuration)
        {
            _servicio = servicio;
            _context = context;
            _configuration = configuration;
        }
        */

        /*
        public UsuarioController(IUsuarioService servicio)
        {
            _servicio = servicio;
        }
        


        public dynamic IniciarSesion([FromBody] Object optData)
        {
            var data = JsonConvert.DeserializeObject<dynamic>(optData.ToString());

            string user = data.usuario.ToString();
            string clave = data.pass.ToString();

            Usuario usuario = _context.Usuarios.Where(x => x.Usuario1 == user && x.Clave == clave).FirstOrDefault();   

            if(usuario == null)
            {
                return new
                {
                    success = false,
                    message = "Credenciales Incorrectas",
                    result = ""
                };
            }

            var jwt = _configuration.GetSection("settings").GetSection("secretkey");

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, jwt.()),

            }
        }

        */

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
