using Microsoft.EntityFrameworkCore;
using MySQL.DataAccess.Models;
using MySQL.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace MySQL.Services.Action
{
    public class CursoService : ICursoService
    {
        private ProyectoContext _context;

        public CursoService (ProyectoContext context)
        {
            _context = context;
        }
        public async Task<RespuestaServicio<Curso>> Actualizar(Curso crs)
        {
            var resp = new RespuestaServicio<Curso>();
            var cr = await _context.Cursos.FirstOrDefaultAsync(x => x.IdCurso == crs.IdCurso);

            if (cr == null)
                resp.AgregarBadRequest("ID de Curso no registrado");
            else
                cr.NCurso = crs.NCurso;
                cr.Descripcion = crs.Descripcion;
                cr.Seccion = crs.Seccion;
                cr.IdGrado = crs.IdGrado;
                cr.Status = crs.Status;

            try
            {
                _context.Cursos.Update(cr);
                await _context.SaveChangesAsync();

                resp.Objeto = cr;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarInternalServerError(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaServicio<Curso>> BuscarPorId(int id)
        {
            var resp = new RespuestaServicio<Curso>();
            var cr = await _context.Cursos.FirstOrDefaultAsync(x => x.IdCurso == id);

            // valida la existencia del ID del Curso
            if (cr == null)
                resp.AgregarBadRequest("ID de Curso no registrado");
            else
                resp.Objeto = cr;
            return resp;
        }

        public async Task<RespuestaServicio<bool>> Eliminar(int id)
        {
            var resp = new RespuestaServicio<bool>();
            var cr = await _context.Cursos.FirstOrDefaultAsync(x => x.IdCurso == id);

            if (cr == null)
                resp.AgregarBadRequest("ID de Curso no registrado");
            else
            {
                try
                {
                    _context.Cursos.Remove(cr);
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

        public async Task<RespuestaServicio<Curso>> Guardar(Curso crs)
        {
            var resp = new RespuestaServicio<Curso>();

            try
            {
                await _context.Cursos.AddAsync(crs);
                await _context.SaveChangesAsync();
                crs.IdCurso = await _context.Cursos.MaxAsync(cr => cr.IdCurso);

                resp.Objeto = crs;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarBadRequest(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaServicio<List<Curso>>> Listar()
        {
            var resp = new RespuestaServicio<List<Curso>>();
            var lista = await _context.Cursos.ToListAsync();

            if (lista != null)
                resp.Objeto = lista;
            else
                resp.AgregarInternalServerError("Se encontro un Error");

            return resp;
        }
    }
}
