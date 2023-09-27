using MySQL.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL.DTO
{
    public class AdminDTO
    {
        public int IdAdmin { get; set; }

        public string PNombre { get; set; } = null!;

        public string SNombre { get; set; } = null!;

        public string? TNombre { get; set; }

        public string PApellido { get; set; } = null!;

        public string SApellido { get; set; } = null!;

        public DateOnly FNacimiento { get; set; }

        public int Telefono { get; set; }

        public DateOnly FContratacion { get; set; }

        public string Direccion { get; set; } = null!;

        public string Correo { get; set; } = null!;

        public decimal? Salario { get; set; }

        public int? IdRol { get; set; }
        //public virtual Puesto? Roles { get; set; }


    }
}
