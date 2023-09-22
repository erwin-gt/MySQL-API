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
    public class PuestoService: iPuestoService
    {
        private ModelContext _context;

        public PuestoService(ModelContext context)
        {
            _context = context;
        }

        public async Task<RespuestaServicio<Puesto>> Actualizar(Puesto puesto)
        {
            var resp = new RespuestaServicio<Puesto>();
            var pst = await _context.Puestos.FirstOrDefaultAsync(x => x.IdRol == puesto.IdRol);

            if (pst == null)
                resp.AgregarBadRequest("ID recibido no registrado");

            else
                pst.Rol = puesto.Rol;
                pst.Descripcion = puesto.Descripcion;

            try
            {
                _context.Puestos.Update(pst);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarInternalServerError(ex.Message);
            }

            return resp;
        }

        public Task<RespuestaServicio<Puesto>> BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RespuestaServicio<bool>> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RespuestaServicio<Puesto>> Guardar(Puesto puesto)
        {
            throw new NotImplementedException();
        }

        public async Task<RespuestaServicio<List<Puesto>>> Listar()
        {
            var resp = new RespuestaServicio<List<Puesto>>();
            var lista = await _context.Puestos.ToListAsync();

            if (lista != null)
                resp.Objeto = lista;
            else
                resp.AgregarInternalServerError("Se encontro un Error");

            return resp;
        }
    }
}
