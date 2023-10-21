using System;
using System.Collections.Generic;

namespace MySQL.DataAccess.Models;

public partial class Administracion
{
    public int IdAdmin { get; set; }

    public string PNombre { get; set; } = null!;

    public string SNombre { get; set; } = null!;

    /// <summary>
    /// Tercer Nombre si existiese
    /// </summary>
    public string? TNombre { get; set; }

    public string PApellido { get; set; } = null!;

    public string SApellido { get; set; } = null!;

    /// <summary>
    /// Fecha de Nacimiento
    /// </summary>
    public DateOnly FNacimiento { get; set; }

    public int Telefono { get; set; }

    /// <summary>
    /// Fecha de Contratacion
    /// </summary>
    public DateOnly FContratacion { get; set; }

    public string Direccion { get; set; } = null!;

    public string Coreo { get; set; } = null!;

    public decimal? Salario { get; set; }

    public int? IdRol { get; set; }

    public virtual Puesto? IdRolNavigation { get; set; }

    public virtual ICollection<Inscripcion> Inscripcions { get; set; } = new List<Inscripcion>();
}
