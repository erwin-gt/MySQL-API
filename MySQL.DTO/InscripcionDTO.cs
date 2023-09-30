using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL.DTO
{
    public class InscripcionDTO
    {
        public int IdInscripcion { get; set; }
        public DateOnly Fecha { get; set; }

        public int? IdCarrera { get; set; }

        public int? IdEstudiante { get; set; }

        public int? IdAdmin { get; set; }
    }
}
