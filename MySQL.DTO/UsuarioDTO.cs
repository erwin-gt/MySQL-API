using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL.DTO
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }

        public string? User { get; set; }

        public string? Correo { get; set; }

        public string? TipoUsuario { get; set; }

        public DateOnly? FCreacion { get; set; }

        public string? Clave { get; set; }
    }
}
