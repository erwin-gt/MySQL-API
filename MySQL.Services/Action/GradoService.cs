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
    public class GradoService : IGradoService
    {
        private ProyectoContext _context;

        public GradoService(ProyectoContext context)
        {
            _context = context;
        }
        public async Task<RespuestaServicio<Grado>> Actualizar(Grado gd)
        {
            var resp = new RespuestaServicio<Grado>();
            var grad = await _context.Grados.FirstOrDefaultAsync(x => x.IdGrado == gd.IdGrado);

            if (grad == null)
                resp.AgregarBadRequest("ID de Carrera no registrado");
            else
                grad.GradoN = gd.GradoN;
                grad.Descripcion = gd.Descripcion;
                
            try
            {
                _context.Grados.Update(grad);
                await _context.SaveChangesAsync();

                resp.Objeto = grad;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarInternalServerError(ex.Message);
            }

            return resp;
        }

        public async  Task<RespuestaServicio<Grado>> BuscarPorId(int id)
        {
            var resp = new RespuestaServicio<Grado>();
            var grad = await _context.Grados.FirstOrDefaultAsync(x => x.IdGrado == id);

            // valida la existencia del ID del Grado
            if (grad == null)
                resp.AgregarBadRequest("ID de Grado no registrado");
            else
                resp.Objeto = grad;
            return resp;
        }

        public async Task<RespuestaServicio<bool>> Eliminar(int id)
        {
            var resp = new RespuestaServicio<bool>();
            var grad = await _context.Grados.FirstOrDefaultAsync(x => x.IdGrado == id);

            if (grad == null)
                resp.AgregarBadRequest("ID de Grado no registrado");
            else
            {
                try
                {
                    _context.Grados.Remove(grad);
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

        public async Task<RespuestaServicio<Grado>> Guardar(Grado gd)
        {
            var resp = new RespuestaServicio<Grado>();

            try
            {
                await _context.Grados.AddAsync(gd);
                await _context.SaveChangesAsync();
                gd.IdGrado = await _context.Grados.MaxAsync(grad => grad.IdGrado);

                resp.Objeto = gd;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarBadRequest(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaServicio<List<Grado>>> Listar()
        {
            var resp = new RespuestaServicio<List<Grado>>();
            var lista = await _context.Grados.ToListAsync();

            if (lista != null)
                resp.Objeto = lista;
            else
                resp.AgregarInternalServerError("Se encontro un Error");

            return resp;
        }
    }
}
