using MySQL.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL.Services.Interface
{
    public interface IAdminService
    {
        Task<RespuestaServicio<List<Administracion>>> Listar();
        Task<RespuestaServicio<Administracion>> BuscarPorId(int id);
        Task<RespuestaServicio<Administracion>> Guardar(Administracion admin);
        Task<RespuestaServicio<Administracion>> Actualizar(Administracion admin);
        Task<RespuestaServicio<bool>> Eliminar(int id);
    }
}
