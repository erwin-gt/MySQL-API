using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL.DTO
{
    public class NotasDTO
    {
        public int IdNota { get; set; }

        public int Nota { get; set; }

        public string? Descripcion { get; set; }

        public int? IdCurso { get; set; }
    }
}
