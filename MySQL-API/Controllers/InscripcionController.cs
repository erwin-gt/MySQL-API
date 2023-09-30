using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySQL.DTO;
using MySQL.Services.Interface;
using MySQL_API.Mappings;

namespace MySQL_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscripcionController : ControllerBase
    {
        private readonly IInscripcionService _servicio;

        public InscripcionController(IInscripcionService servicio)
        {
            _servicio = servicio;
        }

        //Lista la informacion de la Inscripcion
        [HttpGet]
        public async Task<ActionResult<List<InscripcionDTO>>> Listar()
        {
            //utilizado por el servicio creado IInscripcionService
            var retorno = await _servicio.Listar();

            //Validacion del Servicio
            if (retorno.Objeto != null)
                return retorno.Objeto.Select(MapperInscripcion.ToDTO).ToList();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        //Lista la informacion de la Inscripcion segun el ID ingresado
        [HttpGet("{id}")]
        public async Task<ActionResult<InscripcionDTO>> BuscarPorId(int id)
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
        public async Task<ActionResult<InscripcionDTO>> Guardar(InscripcionDTO add)
        {
            var retorno = await _servicio.Guardar(add.ToDatabase());
            //Validacion del Servicio
            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        //Actualizacion de Datos
        [HttpPut]
        public async Task<ActionResult<InscripcionDTO>> Actualizar(InscripcionDTO add)
        {
            var retorno = await _servicio.Actualizar(add.ToDatabase());
            //Validacion del Servicio
            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        //Eliminacion de la Inscripcion segun ID ingresado
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

