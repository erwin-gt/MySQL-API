using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL.DTO
{
    public class CursoDTO
    {
        public int IdCurso { get; set; }


        public string Nombre { get; set; } = null!;

        public int? Cantidad { get; set; }

        public string Seccion { get; set; } = null!;

        public string? Descripcion { get; set; }

        public int? IdGrado { get; set; }

        public string Status { get; set; } = null!;
    }
}
