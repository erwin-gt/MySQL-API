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
        private ProyectoContext _context;

        public PuestoService(ProyectoContext context)
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

        public async Task<RespuestaServicio<Puesto>> BuscarPorId(int id)
        {
            var resp = new RespuestaServicio<Puesto>();
            var pst = await _context.Puestos.FirstOrDefaultAsync(x =>x.IdRol == id);

            //Valida la existencia del Puesto
            if (pst == null)
                resp.AgregarBadRequest("ID ingresado no existe");
            else
                resp.Objeto = pst;
            return resp;
        }

        public async Task<RespuestaServicio<bool>> Eliminar(int id)
        {
            var resp = new RespuestaServicio<bool>();
            var pst = await _context.Puestos.FirstOrDefaultAsync(x => x.IdRol == id);

            if (pst == null)
                resp.AgregarBadRequest("ID ingresado no existe");
            else
            {
                try
                {
                    _context.Puestos.Remove(pst);
                    await _context.SaveChangesAsync() ;
                    resp.Exito = true;
                }

                catch(DbUpdateException ex)
                {
                    resp.AgregarInternalServerError(ex.Message);
                }
            }

            return resp;

        }

        public async Task<RespuestaServicio<Puesto>> Guardar(Puesto puesto)
        {
            var resp = new RespuestaServicio<Puesto>();

            try
            {
                await _context.Puestos.AddAsync(puesto);
                await _context.SaveChangesAsync();
                puesto.IdRol = await _context.Puestos.MaxAsync(rol => rol.IdRol);
                resp.Objeto = puesto;
            }
            catch(DbUpdateException ex)
            {
                resp.AgregarInternalServerError(ex.Message);
            }

            return resp;
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
