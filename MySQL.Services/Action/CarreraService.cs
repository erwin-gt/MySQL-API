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
    public class CarreraService : ICarreraService
    {
        private ProyectoContext _context;

        public CarreraService(ProyectoContext context)
        {
            _context = context;
        }
        public async Task<RespuestaServicio<Carrera>> Actualizar(Carrera crr)
        {
            var resp = new RespuestaServicio<Carrera>();
            var cr = await _context.Carreras.FirstOrDefaultAsync(x => x.IdCarrera == crr.IdCarrera);

            if (cr == null)
                resp.AgregarBadRequest("ID de Carrera no registrado");
            else
                cr.Nombre = crr.Nombre;
                cr.Descripcion = crr.Descripcion;
            
            try
            {
                _context.Carreras.Update(cr);
                await _context.SaveChangesAsync();

                resp.Objeto = cr;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarInternalServerError(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaServicio<Carrera>> BuscarPorId(int id)
        {
            var resp = new RespuestaServicio<Carrera>();
            var cr = await _context.Carreras.FirstOrDefaultAsync(x => x.IdCarrera == id);

            // valida la existencia del ID de la Carrera
            if (cr == null)
                resp.AgregarBadRequest("ID de Carrera no registrado");
            else
                resp.Objeto = cr;
            return resp;
        }

        public async Task<RespuestaServicio<bool>> Eliminar(int id)
        {
            var resp = new RespuestaServicio<bool>();
            var cr = await _context.Carreras.FirstOrDefaultAsync(x => x.IdCarrera == id);

            if (cr == null)
                resp.AgregarBadRequest("ID de Carrera no registrado");
            else
            {
                try
                {
                    _context.Carreras.Remove(cr);
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

        public async Task<RespuestaServicio<Carrera>> Guardar(Carrera crr)
        {
            var resp = new RespuestaServicio<Carrera>();

            try
            {
                await _context.Carreras.AddAsync(crr);
                await _context.SaveChangesAsync();
                crr.IdCarrera = await _context.Carreras.MaxAsync(cr => cr.IdCarrera);

                resp.Objeto = crr;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarBadRequest(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaServicio<List<Carrera>>> Listar()
        {
            var resp = new RespuestaServicio<List<Carrera>>();
            var lista = await _context.Carreras.ToListAsync();

            if (lista != null)
                resp.Objeto = lista;
            else
                resp.AgregarInternalServerError("Se encontro un Error");

            return resp;
        }
    }
}
