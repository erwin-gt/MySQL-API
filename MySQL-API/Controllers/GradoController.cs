using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySQL.DTO;
using MySQL.Services.Interface;
using MySQL_API.Mappings;
using MySQL_API.Mappings.Notas;

namespace MySQL_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradoController : ControllerBase
    {
        private readonly IGradoService _servicio;

        public GradoController(IGradoService servicio)
        {
            _servicio = servicio;
        }

        //Lista la informacion del Grado
        [HttpGet]
        public async Task<ActionResult<List<GradoDTO>>> Listar()
        {
            //utilizado por el servicio creado IGradoService
            var retorno = await _servicio.Listar();

            //Validacion del Servicio
            if (retorno.Objeto != null)
                return retorno.Objeto.Select(MapperGrado.ToDTO).ToList();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        //Lista la informacion del Grado segun el ID ingresado
        [HttpGet("{id}")]
        public async Task<ActionResult<GradoDTO>> BuscarPorId(int id)
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
        public async Task<ActionResult<GradoDTO>> Guardar(GradoDTO gd)
        {
            var retorno = await _servicio.Guardar(gd.ToDatabase());
            //Validacion del Servicio
            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        //Actualizacion de Datos
        [HttpPut]
        public async Task<ActionResult<GradoDTO>> Actualizar(GradoDTO gd)
        {
            var retorno = await _servicio.Actualizar(gd.ToDatabase());
            //Validacion del Servicio
            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        //Eliminacion de Grado segun ID ingresado
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Elimiar(int id)
        {
            var retorno = await _servicio.Eliminar(id);
            //Validacion del Servicios
            if (retorno.Exito)
                return true;
            else
                return StatusCode(retorno.Status, retorno.Error);
        }
    }
}
