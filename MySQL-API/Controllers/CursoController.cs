using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySQL.DTO;
using MySQL.Services.Interface;
using MySQL_API.Mappings;

namespace MySQL_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly ICursoService _servicio;

        public CursoController(ICursoService servicio)
        {
            _servicio = servicio;
        }

        //Lista la informacion del Curso
        [HttpGet]
        public async Task<ActionResult<List<CursoDTO>>> Listar()
        {
            //utilizado por el servicio creado ICursoService
            var retorno = await _servicio.Listar();

            //Validacion del Servicio
            if (retorno.Objeto != null)
                return retorno.Objeto.Select(MapperCurso.ToDTO).ToList();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        //Lista la informacion el Curso segun el ID ingresado
        [HttpGet("{id}")]
        public async Task<ActionResult<CursoDTO>> BuscarPorId(int id)
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
        public async Task<ActionResult<CursoDTO>> Guardar(CursoDTO crs)
        {
            var retorno = await _servicio.Guardar(crs.ToDatabase());
            //Validacion del Servicio
            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        //Actualizacion de Datos
        [HttpPut]
        public async Task<ActionResult<CursoDTO>> Actualizar(CursoDTO crs)
        {
            var retorno = await _servicio.Actualizar(crs.ToDatabase());
            //Validacion del Servicio
            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        //Eliminacion del Curso segun ID ingresado
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

