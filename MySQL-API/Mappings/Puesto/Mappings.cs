using MySQL.DTO;
using MySQL.DataAccess.Models;

namespace MySQL_API.Mappings
{
    public static partial class MapperPuesto
    {
        public static PuestoDTO ToDTO(this Puesto model)
        {
            return new PuestoDTO
            {
                IdRol = model.IdRol,
                Rol = model.Rol,
                Descripcion = model.Descripcion,
            };
        }
    }

    public static partial class MapperPuesto
    {
        public static Puesto ToDatabase(this PuestoDTO dto)
        {
            return new Puesto
            {
                IdRol = dto.IdRol,
                Rol = dto.Rol,
                Descripcion = dto.Descripcion,
            };
        }
    }
}
