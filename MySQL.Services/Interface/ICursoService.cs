using MySQL.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL.Services.Interface
{
    public interface ICursoService
    {
        Task<RespuestaServicio<List<Curso>>> Listar();
        Task<RespuestaServicio<Curso>> BuscarPorId(int id);
        Task<RespuestaServicio<Curso>> Guardar(Curso crs);
        Task<RespuestaServicio<Curso>> Actualizar(Curso crs);
        Task<RespuestaServicio<bool>> Eliminar(int id);
    }
}
