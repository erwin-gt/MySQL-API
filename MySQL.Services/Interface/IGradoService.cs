using MySQL.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL.Services.Interface
{
    public interface IGradoService
    {
        Task<RespuestaServicio<List<Grado>>> Listar();
        Task<RespuestaServicio<Grado>> BuscarPorId(int id);
        Task<RespuestaServicio<Grado>> Guardar(Grado gd);
        Task<RespuestaServicio<Grado>> Actualizar(Grado gd);
        Task<RespuestaServicio<bool>> Eliminar(int id);
    }
}
