using MySQL.DataAccess.Models;
using MySQL.DTO;

namespace MySQL_API.Mappings
{
    public static partial class MapperCarrera
    {
        public static CarreraDTO ToDTO(this Carrera model)
        {
            return new CarreraDTO
            {
                IdCarrera = model.IdCarrera,
                Nombre = model.Nombre,
                Descripcion = model.Descripcion,
            };
        }
    }

    public static partial class MapperCarrera
    {
        public static Carrera ToDatabase(this CarreraDTO dto)
        {
            return new Carrera
            {
                IdCarrera = dto.IdCarrera,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
            };
        }
    }
}
