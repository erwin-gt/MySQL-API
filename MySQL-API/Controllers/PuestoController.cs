using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySQL.DTO;
using MySQL.Services.Interface;
using MySQL_API.Mappings;

namespace MySQL_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuestoController : ControllerBase
    {
        private readonly iPuestoService _servicio;

        public PuestoController(iPuestoService servicio)
        {
            _servicio = servicio;
        }

        //Lista la informacion de los puestos
        [HttpGet]
        public async Task<ActionResult<List<PuestoDTO>>> Listar()
        {
            //utilizado por el servicio creado IPuestoService
            var retorno = await _servicio.Listar();

            //Validacion del Servicio
            if (retorno.Objeto != null)
                return retorno.Objeto.Select(MapperPuesto.ToDTO).ToList();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }
    }
}
