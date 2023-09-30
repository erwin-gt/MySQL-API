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
    public class NoteService : INotaService
    {
        private ProyectoContext _context;

        public NoteService(ProyectoContext context)
        {
            _context = context;
        }
        public async Task<RespuestaServicio<Notum>> Actualizar(Notum nt)
        {
            var resp = new RespuestaServicio<Notum>();
            var note = await _context.Nota.FirstOrDefaultAsync(x => x.IdNota == nt.IdNota);

            if (note == null)
                resp.AgregarBadRequest("ID de Carrera no registrado");
            else
                note.Nota = nt.Nota;
                note.Descripcion = nt.Descripcion;

            try
            {
                _context.Nota.Update(note);
                await _context.SaveChangesAsync();

                resp.Objeto = note;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarInternalServerError(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaServicio<Notum>> BuscarPorId(int id)
        {
            var resp = new RespuestaServicio<Notum>();
            var note = await _context.Nota.FirstOrDefaultAsync(x => x.IdNota == id);

            // valida la existencia del ID de la Nota
            if (note == null)
                resp.AgregarBadRequest("ID de Nota no registrado");
            else
                resp.Objeto = note;
            return resp;
        }

        public async Task<RespuestaServicio<bool>> Eliminar(int id)
        {
            var resp = new RespuestaServicio<bool>();
            var note = await _context.Nota.FirstOrDefaultAsync(x => x.IdNota == id);

            if (note == null)
                resp.AgregarBadRequest("ID de Nota no registrado");
            else
            {
                try
                {
                    _context.Nota.Remove(note);
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

        public async Task<RespuestaServicio<Notum>> Guardar(Notum nt)
        {
            var resp = new RespuestaServicio<Notum>();

            try
            {
                await _context.Nota.AddAsync(nt);
                await _context.SaveChangesAsync();
                nt.IdNota = await _context.Nota.MaxAsync(note => note.IdNota);

                resp.Objeto = nt;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarBadRequest(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaServicio<List<Notum>>> Listar()
        {
            var resp = new RespuestaServicio<List<Notum>>();
            var lista = await _context.Nota.ToListAsync();

            if (lista != null)
                resp.Objeto = lista;
            else
                resp.AgregarInternalServerError("Se encontro un Error");

            return resp;
        }
    }
}
