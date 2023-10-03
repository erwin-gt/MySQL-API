using MySQL.DataAccess.Models;
using MySQL.DTO;

namespace MySQL_API.Mappings
{
    public static partial class MapperGrado
    {
        public static GradoDTO ToDTO(this Grado model)
        {
            return new GradoDTO
            {
                IdGrado = model.IdGrado,
                Nombre = model.GradoN,
                Descripcion = model.Descripcion,
                IdCarrera = model.IdCarrera,
            

            };
        }
    }

    public static partial class MapperGrado
    {
        public static Grado ToDatabase(this GradoDTO dto)
        {
            return new Grado
            {
                IdGrado = dto.IdGrado,
                GradoN = dto.Nombre,
                Descripcion = dto.Descripcion,
                IdCarrera = dto.IdCarrera,
               
            };
        }
    }
}
