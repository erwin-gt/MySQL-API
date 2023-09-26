﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL.DTO
{
    public class EstudianteDTO
    {
        public int IdEstudiante { get; set; }

        public string? PNombre { get; set; }

        public string? SNombre { get; set; }

        public string? TNombre { get; set; }

        public string? PApellido { get; set; }

        public string? SApellido { get; set; }

        public DateOnly? FNacimiento { get; set; }

        public string? Telefono { get; set; }

        public DateOnly? FContratacion { get; set; }

        public string? Direccion { get; set; }

        public string? CElectronico { get; set; }

        public string? NomEncargado { get; set; }

        public string? CelEncargado { get; set; }

        public string? Carnet { get; set; }

        public string? Status { get; set; }
    }
}
