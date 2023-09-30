using MySQL.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL.Services.Interface
{
    public interface IInscripcionService
    {
        Task<RespuestaServicio<List<Inscripcion>>> Listar();
        Task<RespuestaServicio<Inscripcion>> BuscarPorId(int id);
        Task<RespuestaServicio<Inscripcion>> Guardar(Inscripcion add);
        Task<RespuestaServicio<Inscripcion>> Actualizar(Inscripcion add);
        Task<RespuestaServicio<bool>> Eliminar(int id);
    }
}
