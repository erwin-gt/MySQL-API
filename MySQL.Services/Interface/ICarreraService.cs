using MySQL.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL.Services.Interface
{
    public interface ICarreraService
    {
        Task<RespuestaServicio<List<Carrera>>> Listar();
        Task<RespuestaServicio<Carrera>> BuscarPorId(int id);
        Task<RespuestaServicio<Carrera>> Guardar(Carrera crr);
        Task<RespuestaServicio<Carrera>> Actualizar(Carrera crr);
        Task<RespuestaServicio<bool>> Eliminar(int id);
    }
}
