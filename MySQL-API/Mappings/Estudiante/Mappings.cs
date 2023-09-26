using MySQL.DataAccess.Models;
using MySQL.DTO;

namespace MySQL_API.Mappings
{
    public static partial class MapperStudent
    {
        public static EstudianteDTO ToDTO(this Estudiante model)
        {
            return new EstudianteDTO
            {
                IdEstudiante = model.IdEstudiante,
                PNombre = model.PNombre,
                SNombre = model.SNombre,
                TNombre = model.TNombre,
                PApellido = model.PApellido,
                SApellido = model.SApellido,
                FNacimiento = model.FNacimiento,
                Telefono = model.Telefono,
                Direccion = model.Direccion,
                CElectronico = model.CElectronico,
                NomEncargado = model.NomEncargado,
                CelEncargado = model.CelEncargado,
                Carnet = model.Carnet,
                Status = model.Status,

            };
        }
    }

    public static partial class MapperStudent
    {
        public static Estudiante ToDatabase(this EstudianteDTO dto)
        {
            return new Estudiante
            {
                IdEstudiante = dto.IdEstudiante,
                PNombre = dto.PNombre,
                SNombre = dto.SNombre,
                TNombre= dto.TNombre,
                PApellido= dto.PApellido,
                SApellido = dto.SApellido,
                FNacimiento = dto.FNacimiento,
                Telefono = dto.Telefono,
                Direccion = dto.Direccion,
                CElectronico = dto.CElectronico,
                NomEncargado = dto.NomEncargado,
                CelEncargado = dto.CelEncargado,
                Carnet = dto.Carnet,
                Status= dto.Status,
            };
        }
    }
}
