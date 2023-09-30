using MySQL.DataAccess.Models;
using MySQL.DTO;

namespace MySQL_API.Mappings
{
    public static partial class MapperInscripcion
    {
        public static InscripcionDTO ToDTO(this Inscripcion model)
        {
            return new InscripcionDTO
            {
               IdInscripcion = model.IdInscripcion,
                Fecha = model.FIncripcion,
                IdAdmin = model.IdAdmin,
                IdCarrera = model.IdCarrera,
                IdEstudiante = model.IdEstudiante,
            };
        }
    }

    public static partial class MapperInscripcion
    {
        public static Inscripcion ToDatabase(this InscripcionDTO dto)
        {
            return new Inscripcion
            {
                IdInscripcion = dto.IdInscripcion,
                FIncripcion = dto.Fecha,
                IdAdmin = dto.IdAdmin,
                IdEstudiante = dto.IdEstudiante,
                IdCarrera = dto.IdCarrera,
            };
        }
    }
}
