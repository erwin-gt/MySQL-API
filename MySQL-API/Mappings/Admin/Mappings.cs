using MySQL.DataAccess.Models;
using MySQL.DTO;

namespace MySQL_API.Mappings.Admin
{
    public static partial class MapperAdmin
    {
        public static AdminDTO ToDTO(this Administracion model)
        {
            return new AdminDTO
            {
                IdAdmin = model.IdAdmin,
                PNombre = model.PNombre,
                SNombre = model.SNombre,
                TNombre = model.TNombre,
                PApellido = model.PApellido,
                SApellido = model.SApellido,
                FNacimiento = model.FNacimiento,
                Telefono = model.Telefono,
                FContratacion = model.FContratacion,
                Direccion = model.Direccion,
                Correo = model.Coreo,
                Salario = model.Salario,
                IdRol = model.IdRol,
                //Roles = model.IdRolNavigation,
               
                
            };
        }
    }

    public static partial class MapperAdmin
    {
        public static Administracion ToDatabase(this AdminDTO dto)
        {
            return new Administracion
            {
                IdAdmin = dto.IdAdmin,
                PNombre = dto.PNombre,
                SNombre = dto.SNombre,
                TNombre = dto.TNombre,
                PApellido = dto.PApellido,
                SApellido = dto.SApellido,
                FNacimiento= dto.FNacimiento,
                Telefono = dto.Telefono,
                FContratacion= dto.FContratacion,
                Direccion= dto.Direccion,
                Coreo = dto.Correo,
                Salario = dto.Salario,
                IdRol = dto.IdRol,
                //IdRolNavigation = dto.Roles,
            

            };
        }
    }
}
