using MySQL.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL.Services.Interface
{
    public interface ICatedraService
    {
        Task<RespuestaServicio<List<Catedratico>>> Listar();
        Task<RespuestaServicio<Catedratico>> BuscarPorId(int id);
        Task<RespuestaServicio<Catedratico>> Guardar(Catedratico catedra);
        Task<RespuestaServicio<Catedratico>> Actualizar(Catedratico catedra);
        Task<RespuestaServicio<bool>> Eliminar(int id);
    }
}
