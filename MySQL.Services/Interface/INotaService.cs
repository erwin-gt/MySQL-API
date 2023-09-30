using MySQL.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL.Services.Interface
{
    public interface INotaService
    {
        Task<RespuestaServicio<List<Notum>>> Listar();
        Task<RespuestaServicio<Notum>> BuscarPorId(int id);
        Task<RespuestaServicio<Notum>> Guardar(Notum nt);
        Task<RespuestaServicio<Notum>> Actualizar(Notum nt);
        Task<RespuestaServicio<bool>> Eliminar(int id);
    }
}
