using MySQL.DataAccess.Models;
using MySQL.DTO;

namespace MySQL_API.Mappings
{
    public static partial class MapperUser
    {
        public static UsuarioDTO ToDTO(this Usuario model)
        {
            return new UsuarioDTO
            {
                IdUsuario = model.IdUsuario,
                User = model.Usuario1,
                Correo = model.Correo,
                TipoUsuario = model.TipoUsuario,
                FCreacion = model.FCreacion,
                Clave = model.Clave,
            };
        }
    }

    public static partial class MapperUser
    {
        public static Usuario ToDatabase(this UsuarioDTO dto)
        {
            return new Usuario
            {
                IdUsuario = dto.IdUsuario,
                Usuario1 = dto.User,
                Correo = dto.Correo,
                TipoUsuario = dto.TipoUsuario,
                FCreacion = dto.FCreacion,
                Clave = dto.Clave,
            };
        }
    }
}
