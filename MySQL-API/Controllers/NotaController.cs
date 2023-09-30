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
    public class NotaController : ControllerBase
    {
        private readonly INotaService _servicio;

        public NotaController(INotaService servicio)
        {
            _servicio = servicio;
        }

        //Lista la informacion de la Nota
        [HttpGet]
        public async Task<ActionResult<List<NotasDTO>>> Listar()
        {
            //utilizado por el servicio creado INotaService
            var retorno = await _servicio.Listar();

            //Validacion del Servicio
            if (retorno.Objeto != null)
                return retorno.Objeto.Select(MapperNota.ToDTO).ToList();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        //Lista la informacion de la Nota segun el ID ingresado
        [HttpGet("{id}")]
        public async Task<ActionResult<NotasDTO>> BuscarPorId(int id)
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
        public async Task<ActionResult<NotasDTO>> Guardar(NotasDTO nt)
        {
            var retorno = await _servicio.Guardar(nt.ToDatabase());
            //Validacion del Servicio
            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        //Actualizacion de Datos
        [HttpPut]
        public async Task<ActionResult<NotasDTO>> Actualizar(NotasDTO nt)
        {
            var retorno = await _servicio.Actualizar(nt.ToDatabase());
            //Validacion del Servicio
            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        //Eliminacion de la Nota segun ID ingresado
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
