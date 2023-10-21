using MySQL.DataAccess.Models;
using MySQL.DTO;

namespace MySQL_API.Mappings
{
    public static partial class MapperCate
    {
        public static CatedraticoDTO ToDTO(this Catedratico model)
        {
            return new CatedraticoDTO
            {
                IdCatedratico = model.IdCatedratico,
                PNombre = model.PNombre,
                SNombre = model.SNombre,
                TNombre = model.TNombre,
                PApellido = model.PApellido,
                SApellido = model.SApellido,
                FNacimiento = model.FNacimiento,
                Telefono = model.Telefono,
                FContratacion = model.FContratacion,
                Direccion = model.Direccion,
                Correo = model.Correo,
                Salario = model.Salario,
                Estatus = model.Estatus,
                


            };
        }
    }

    public static partial class MapperCate
    {
        public static Catedratico ToDatabase(this CatedraticoDTO dto)
        {
            return new Catedratico
            {
                IdCatedratico = dto.IdCatedratico,
                PNombre = dto.PNombre,
                SNombre = dto.SNombre,
                TNombre = dto.TNombre,
                PApellido = dto.PApellido,
                SApellido = dto.SApellido,
                FNacimiento = dto.FNacimiento,
                Telefono = dto.Telefono,
                FContratacion = dto.FContratacion,
                Direccion = dto.Direccion,
                Correo = dto.Correo,
                Salario = dto.Salario,
                Estatus = dto.Estatus,
   


            };
        }
    }
}
