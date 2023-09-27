using System;
using System.Collections.Generic;

namespace MySQL.DataAccess.Models;

public partial class Administracion
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

    public string Coreo { get; set; } = null!;

    public decimal? Salario { get; set; }

    public int? IdRol { get; set; }

    public virtual Puesto? IdRolNavigation { get; set; }

    public virtual ICollection<Inscripcion> Inscripcions { get; set; } = new List<Inscripcion>();
}
