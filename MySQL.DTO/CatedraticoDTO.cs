using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL.DTO
{
    public class CatedraticoDTO
    {
        public int IdCatedratico { get; set; }

        public string? PNombre { get; set; } 

        public string SNombre { get; set; }

        public string? TNombre { get; set; }

        public string? PApellido { get; set; } 

        public string? SApellido { get; set; }

        public DateOnly? FNacimiento { get; set; }

        public int? Telefono { get; set; }

        public DateOnly? FContratacion { get; set; }

        public string? Direccion { get; set; }

        public string? Correo { get; set; }

        public decimal? Salario { get; set; }

        public string Estatus { get; set; }
    }
}
