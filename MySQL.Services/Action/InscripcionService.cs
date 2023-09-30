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
    public class InscripcionService : IInscripcionService
    {
        private ProyectoContext _context;

        public InscripcionService(ProyectoContext context)
        {
            _context = context;
        }
        public async Task<RespuestaServicio<Inscripcion>> Actualizar(Inscripcion add)
        {
            var resp = new RespuestaServicio<Inscripcion>();
            var ins = await _context.Inscripcions.FirstOrDefaultAsync(x => x.IdInscripcion == add.IdInscripcion);

            if (ins == null)
                resp.AgregarBadRequest("ID de Inscripcion no registrado");
            else
                ins.IdCarrera = add.IdCarrera;
                ins.IdAdmin = add.IdAdmin;
                ins.IdEstudiante = add.IdEstudiante;

            try
            {
                _context.Inscripcions.Update(ins);
                await _context.SaveChangesAsync();

                resp.Objeto = ins;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarInternalServerError(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaServicio<Inscripcion>> BuscarPorId(int id)
        {
            var resp = new RespuestaServicio<Inscripcion>();
            var ins = await _context.Inscripcions.FirstOrDefaultAsync(x => x.IdInscripcion == id);

            // valida la existencia del ID de la Inscripcion
            if (ins == null)
                resp.AgregarBadRequest("ID de la Inscripcion no registrado");
            else
                resp.Objeto = ins;
            return resp;
        }

        public async Task<RespuestaServicio<bool>> Eliminar(int id)
        {
            var resp = new RespuestaServicio<bool>();
            var ins = await _context.Inscripcions.FirstOrDefaultAsync(x => x.IdInscripcion == id);

            if (ins == null)
                resp.AgregarBadRequest("ID de la Inscripcion no registrado");
            else
            {
                try
                {
                    _context.Inscripcions.Remove(ins);
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

        public async Task<RespuestaServicio<Inscripcion>> Guardar(Inscripcion add)
        {
            var resp = new RespuestaServicio<Inscripcion>();

            try
            {
                await _context.Inscripcions.AddAsync(add);
                await _context.SaveChangesAsync();
                add.IdInscripcion = await _context.Inscripcions.MaxAsync(ins => ins.IdInscripcion);

                resp.Objeto = add;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarBadRequest(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaServicio<List<Inscripcion>>> Listar()
        {
            var resp = new RespuestaServicio<List<Inscripcion>>();
            var lista = await _context.Inscripcions.ToListAsync();

            if (lista != null)
                resp.Objeto = lista;
            else
                resp.AgregarInternalServerError("Se encontro un Error");

            return resp;
        }
    }
}
