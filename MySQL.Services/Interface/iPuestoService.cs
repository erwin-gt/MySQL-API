using MySQL.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL.Services.Interface
{
    public interface iPuestoService
    {
        Task<RespuestaServicio<List<Puesto>>> Listar();
        Task<RespuestaServicio<Puesto>> BuscarPorId(int id);
        Task<RespuestaServicio<Puesto>> Guardar(Puesto puesto);
        Task<RespuestaServicio<Puesto>> Actualizar (Puesto puesto);
        Task<RespuestaServicio<bool>> Eliminar (int id);
    }
}
