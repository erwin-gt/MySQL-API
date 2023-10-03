using MySQL.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL.DTO
{
    public class GradoDTO
    {
        public int IdGrado { get; set; }

        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public int? IdCarrera { get; set; }

        
    }
}
