using MySQL.DataAccess.Models;
using MySQL.DTO;

namespace MySQL_API.Mappings.Notas
{
 
        public static partial class MapperNota
        {
            public static NotasDTO ToDTO(this Notum model)
            {
                return new NotasDTO
                {
                    IdNota = model.IdNota,
                    Nota = model.Nota,
                    Descripcion = model.Descripcion,
                    IdCurso = model.IdCurso,

                };
            }
        }

        public static partial class MapperNota
        {
            public static Notum ToDatabase(this NotasDTO dto)
            {
                return new Notum
                {
                    IdNota = dto.IdNota,
                    Nota = dto.Nota,
                    Descripcion = dto.Descripcion,
                    IdCurso = dto.IdCurso,
                };
            }
        }
    }
