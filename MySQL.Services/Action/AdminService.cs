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
    public class AdminService : IAdminService
    {
        private ProyectoContext _context;

        public AdminService(ProyectoContext context)
        {
            _context = context;
        }

        public async Task<RespuestaServicio<Administracion>> Actualizar(Administracion admin)
        {
            var resp = new RespuestaServicio<Administracion>();
            var adm = await _context.Administracions.FirstOrDefaultAsync(x => x.IdAdmin == admin.IdAdmin);

            if (adm == null)
                resp.AgregarBadRequest("ID de Administracion no registrado");
            else
                adm.PNombre = admin.PNombre;
                adm.SNombre = admin.SNombre;
                adm.TNombre = admin.TNombre;
                adm.PApellido = admin.PApellido;
                adm.SApellido = admin.SApellido;
                adm.Telefono = admin.Telefono;
                adm.Direccion = admin.Direccion;
                adm.Coreo = admin.Coreo;
                adm.Salario = admin.Salario;
                adm.IdRol = admin.IdRol;

            try
            {
                _context.Administracions.Update(adm);
                await _context.SaveChangesAsync();

                resp.Objeto = adm;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarInternalServerError(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaServicio<Administracion>> BuscarPorId(int id)
        {
            var resp = new RespuestaServicio<Administracion>();
            var adm = await _context.Administracions.FirstOrDefaultAsync(x => x.IdAdmin == id);

            // valida la existencia del ID de Administracion
            if (adm == null)
                resp.AgregarBadRequest("ID de Administracion no registrado");
            else
                resp.Objeto = adm;
            return resp;
        }

        public async Task<RespuestaServicio<bool>> Eliminar(int id)
        {
            var resp = new RespuestaServicio<bool>();
            var adm = await _context.Administracions.FirstOrDefaultAsync(x => x.IdAdmin == id);

            if (adm == null)
                resp.AgregarBadRequest("ID de Administracion no registrado");
            else
            {
                try
                {
                    _context.Administracions.Remove(adm);
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

        public async Task<RespuestaServicio<Administracion>> Guardar(Administracion admin)
        {
            var resp = new RespuestaServicio<Administracion>();

            try
            {
                await _context.Administracions.AddAsync(admin);
                await _context.SaveChangesAsync();
                admin.IdAdmin = await _context.Administracions.MaxAsync(adm => adm.IdAdmin);

                resp.Objeto = admin;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarBadRequest(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaServicio<List<Administracion>>> Listar()
        {
            var resp = new RespuestaServicio<List<Administracion>>();
            var lista = await _context.Administracions.ToListAsync();

            if (lista != null)
                resp.Objeto = lista;
            else
                resp.AgregarInternalServerError("Se encontro un Error");

            return resp;
        }
    }
}
