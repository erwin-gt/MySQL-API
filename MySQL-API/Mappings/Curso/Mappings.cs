using MySQL.DataAccess.Models;
using MySQL.DTO;

namespace MySQL_API.Mappings
{
    public static partial class MapperCurso
    {
        public static CursoDTO ToDTO(this Curso model)
        {
            return new CursoDTO
            {
                IdCurso = model.IdCurso,
                Nombre = model.NCurso,
                Cantidad = model.CantAlumno,
                Seccion = model.Seccion,
                Descripcion = model.Descripcion,
                Status = model.Status,
                IdGrado = model.IdGrado,
            };
        }
    }

    public static partial class MapperCurso
    {
        public static Curso ToDatabase(this CursoDTO dto)
        {
            return new Curso
            {
                IdCurso = dto.IdCurso,
                NCurso = dto.Nombre,
                CantAlumno = dto.Cantidad,
                Seccion = dto.Seccion,
                Descripcion = dto.Descripcion,
                Status = dto.Status,
                IdGrado = dto.IdGrado,
            };
        }
    }
} 
