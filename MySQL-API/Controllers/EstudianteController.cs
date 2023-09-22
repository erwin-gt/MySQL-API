﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySQL.DTO;
using MySQL.Services.Interface;
using MySQL_API.Mappings;

namespace MySQL_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly IEstudianteService _servicio;

        public EstudianteController(IEstudianteService servicio)
        {
            _servicio = servicio;
        }

        //Lista la informacion de los Estudiantes
        [HttpGet]
        public async Task<ActionResult<List<EstudianteDTO>>> Listar()
        {
            //utilizado por el servicio creadoIEstudianteService
            var retorno = await _servicio.Listar();

            //Validacion del Servicio
            if (retorno.Objeto != null)
                return retorno.Objeto.Select(MapperStudent.ToDTO).ToList();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }
    }
}
