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
    public class CatedraService : ICatedraService
    {
        private ProyectoContext _context;

        public CatedraService(ProyectoContext context)
        {
            _context = context;
        }

        public async Task<RespuestaServicio<Catedratico>> Actualizar(Catedratico catedra)

        {
            var resp = new RespuestaServicio<Catedratico>();
            var cate = await _context.Catedraticos.FirstOrDefaultAsync(x => x.IdCatedratico == catedra.IdCatedratico);

            if (cate == null)
                resp.AgregarBadRequest("ID de Catedratico no registrado");
            else
                cate.PNombre = catedra.PNombre;
                cate.SNombre = catedra.SNombre;
                cate.TNombre = catedra.TNombre;
                cate.PApellido = catedra.PApellido;
                cate.SApellido = catedra.SApellido;
                cate.Telefono = catedra.Telefono;
                cate.Direccion = catedra.Direccion;
                cate.Correo = catedra.Correo;
                cate.Salario = catedra.Salario;
                cate.Estatus = catedra.Estatus;

            try
            {
                _context.Catedraticos.Update(cate);
                await _context.SaveChangesAsync();

                resp.Objeto = cate;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarInternalServerError(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaServicio<Catedratico>> BuscarPorId(int id)
        {
            var resp = new RespuestaServicio<Catedratico>();
            var cate = await _context.Catedraticos.FirstOrDefaultAsync(x => x.IdCatedratico == id);

            // valida la existencia del ID de Catedratico
            if (cate == null)
                resp.AgregarBadRequest("ID de Catedratico no registrado");
            else
                resp.Objeto = cate;
            return resp;
        }

        public async Task<RespuestaServicio<bool>> Eliminar(int id)
        {
            var resp = new RespuestaServicio<bool>();
            var cate = await _context.Catedraticos.FirstOrDefaultAsync(x => x.IdCatedratico == id);

            if (cate == null)
                resp.AgregarBadRequest("ID de Catedratico no registrado");
            else
            {
                try
                {
                    _context.Catedraticos.Remove(cate);
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

        public async Task<RespuestaServicio<Catedratico>> Guardar(Catedratico catedra)
        {
            var resp = new RespuestaServicio<Catedratico>();

            try
            {
                await _context.Catedraticos.AddAsync(catedra);
                await _context.SaveChangesAsync();
                catedra.IdCatedratico = await _context.Catedraticos.MaxAsync(cate => cate.IdCatedratico);

                resp.Objeto = catedra;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarBadRequest(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaServicio<List<Catedratico>>> Listar()
        {
            var resp = new RespuestaServicio<List<Catedratico>>();
            var lista = await _context.Catedraticos.ToListAsync();

            if (lista != null)
                resp.Objeto = lista;
            else
                resp.AgregarInternalServerError("Se encontro un Error");

            return resp;
        }
    }
}
