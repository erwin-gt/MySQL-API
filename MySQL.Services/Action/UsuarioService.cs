

using MySQL.Services.Interface;

using MySQL.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace MySQL.Services.Action
{
    public class UsuarioService : IUsuarioService
    {
        private ProyectoContext _context;

        public UsuarioService(ProyectoContext context)
        {
            _context = context;
        }

      

        public async Task<RespuestaServicio<Usuario>> Actualizar(Usuario usr)
        {
            var resp = new RespuestaServicio<Usuario>();
            var user = await _context.Usuarios.FirstOrDefaultAsync(x => x.IdUsuario == usr.IdUsuario);

            if (user == null)
                resp.AgregarBadRequest("ID de Usuario no registrado");
            else
                user.Clave = usr.Clave;

            try
            {
                _context.Usuarios.Update(user);
                await _context.SaveChangesAsync();

                resp.Objeto = user;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarInternalServerError(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaServicio<Usuario>> BuscarPorId(int id)
        {
            var resp = new RespuestaServicio<Usuario>();
            var user = await _context.Usuarios.FirstOrDefaultAsync(x => x.IdUsuario == id);

            // valida la existencia del ID del Usuario
            if (user == null)
                resp.AgregarBadRequest("ID de Usuario no registrado");
            else
                resp.Objeto = user;
            return resp;
        }

        public async Task<RespuestaServicio<bool>> Eliminar(int id)
        {
            var resp = new RespuestaServicio<bool>();
            var usr = await _context.Usuarios.FirstOrDefaultAsync(x => x.IdUsuario == id);

            if (usr == null)
                resp.AgregarBadRequest("ID de Usuario no registrado");
            else
            {
                try
                {
                    _context.Usuarios.Remove(usr);
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

        public async Task<RespuestaServicio<List<Usuario>>> Listar()
        {
            var resp = new RespuestaServicio<List<Usuario>>();
            var lista = await _context.Usuarios.ToListAsync();

            if (lista != null)
                resp.Objeto = lista;
            else
                resp.AgregarInternalServerError("Se encontro un Error");

            return resp;
        }
    }
}
