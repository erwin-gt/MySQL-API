using MySQL.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL.Services.Interface
{
    public interface IEstudianteService
    {
        Task<RespuestaServicio<List<Estudiante>>> Listar();
        Task<RespuestaServicio<Estudiante>> BuscarPorId(int id);
        Task<RespuestaServicio<Estudiante>> Guardar(Estudiante stu);
        Task<RespuestaServicio<Estudiante>> Actualizar(Estudiante stu);
        Task<RespuestaServicio<bool>> Eliminar(int id);
    }
}
