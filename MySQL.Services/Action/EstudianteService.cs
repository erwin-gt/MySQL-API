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

        public async Task<RespuestaServicio<Estudiante>> Actualizar(Estudiante stu)
        {
            var resp = new RespuestaServicio<Estudiante>();
            var std = await _context.Estudiantes.FirstOrDefaultAsync(x => x.IdEstudiante == stu.IdEstudiante);

            if (std == null)
                resp.AgregarBadRequest("ID de Estudiante no registrado");
            else
                std.PNombre = stu.PNombre;
                std.SNombre = stu.SNombre;
                std.TNombre = stu.TNombre;
                std.PApellido = stu.PApellido;
                std.SApellido = stu.SApellido;
                std.FNacimiento = stu.FNacimiento;
                std.Telefono = stu.Telefono;
                std.Direccion = stu.Direccion;
                std.CelEncargado = stu.CelEncargado;
                std.CElectronico = stu.CElectronico;
                std.NomEncargado = stu.NomEncargado;
                std.Status = stu.Status;
            try
            {
                _context.Estudiantes.Update(std);
                await _context.SaveChangesAsync();

                resp.Objeto = std;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarInternalServerError(ex.Message);
            }
             
            return resp;
        }

        public async Task<RespuestaServicio<Estudiante>> BuscarPorId(int id)
        {
            var resp = new RespuestaServicio<Estudiante>();
            var std = await _context.Estudiantes.FirstOrDefaultAsync(x => x.IdEstudiante == id);

            // valida la existencia del ID del Estudiante
            if (std == null)
                resp.AgregarBadRequest("ID de Estudiante no registrado");
            else
                resp.Objeto = std;
            return resp;
        }

        public async Task<RespuestaServicio<bool>> Eliminar(int id)
        {
            var resp = new RespuestaServicio<bool>();
            var std = await _context.Estudiantes.FirstOrDefaultAsync(x => x.IdEstudiante == id);

            if (std == null)
                resp.AgregarBadRequest("ID de Estudiante no registrado");
            else
            {
                try
                {
                    _context.Estudiantes.Remove(std);
                    await _context.SaveChangesAsync();
                    resp.Exito = true;
                }
                catch (DbUpdateException ex)
                {
                    resp.AgregarInternalServerError(ex.Message);
                }
            }

            return resp;
        }

        public async Task<RespuestaServicio<Estudiante>> Guardar(Estudiante stu)
        {
            var resp = new RespuestaServicio<Estudiante>();

            try
            {
                await _context.Estudiantes.AddAsync(stu);
                await _context.SaveChangesAsync();
                stu.IdEstudiante = await _context.Estudiantes.MaxAsync(std => std.IdEstudiante);

                resp.Objeto = stu;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarBadRequest(ex.Message);
            }

            return resp;
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

