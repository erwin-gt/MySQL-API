using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySQL.DTO;
using MySQL.Services.Interface;
using MySQL_API.Mappings;
using MySQL_API.Mappings.Admin;

namespace MySQL_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _servicio;

        public AdminController(IAdminService servicio)
        {
            _servicio = servicio;
        }

        //Lista la informacion de Administracion
        [HttpGet]
        public async Task<ActionResult<List<AdminDTO>>> Listar()
        {
            //utilizado por el servicio creado IAdminService
            var retorno = await _servicio.Listar();

            //Validacion del Servicio
            if (retorno.Objeto != null)
                return retorno.Objeto.Select(MapperAdmin.ToDTO).ToList();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        //Lista la informacion de Administracion segun el ID ingresado
        [HttpGet("{id}")]
        public async Task<ActionResult<AdminDTO>> BuscarPorId(int id)
        {
            var retorno = await _servicio.BuscarPorId(id);
            //Validacion del Servicio
            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        //Ingreso de datos
        [HttpPost]
        public async Task<ActionResult<AdminDTO>> Guardar(AdminDTO adm)
        {
            var retorno = await _servicio.Guardar(adm.ToDatabase());
            //Validacion del Servicio
            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        //Actualizacion de Datos
        [HttpPut]
        public async Task<ActionResult<AdminDTO>> Actualizar(AdminDTO adm)
        {
            var retorno = await _servicio.Actualizar(adm.ToDatabase());
            //Validacion del Servicio
            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        //Eliminacion de Administracion segun ID ingresado
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
