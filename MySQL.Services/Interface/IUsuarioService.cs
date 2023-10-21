using MySQL.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL.Services.Interface
{
    public interface IUsuarioService
    {
        Task<RespuestaServicio<List<Usuario>>> Listar();
        Task<RespuestaServicio<Usuario>> BuscarPorId(int id);    
        Task<RespuestaServicio<Usuario>> Actualizar(Usuario usr);
        Task<RespuestaServicio<bool>> Eliminar(int id);
    }
}
