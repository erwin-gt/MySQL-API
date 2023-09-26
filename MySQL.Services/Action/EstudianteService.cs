using Microsoft.EntityFrameworkCore;
using MySQL.DataAccess.Models;
using MySQL.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL.Services.Action
{
    public class EstudianteService : IEstudianteService
    {
        private ProyectoContext _context;

        public EstudianteService(ProyectoContext context)
        {
            _context = context;
        }

        public Task<RespuestaServicio<Estudiante>> Actualizar(Estudiante stu)
        {
            throw new NotImplementedException();
        }

        public Task<RespuestaServicio<Estudiante>> BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RespuestaServicio<bool>> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RespuestaServicio<Estudiante>> Guardar(Estudiante stu)
        {
            throw new NotImplementedException();
        }

        public async Task<RespuestaServicio<List<Estudiante>>> Listar()
        {
            var resp = new RespuestaServicio<List<Estudiante>>();
            var lista = await _context.Estudiantes.ToListAsync();

            if (lista != null)
                resp.Objeto = lista;
            else
                resp.AgregarInternalServerError("Se encontro un Error");

            return resp;
        }
    }
}

