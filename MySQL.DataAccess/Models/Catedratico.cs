using System;
using System.Collections.Generic;

namespace MySQL.DataAccess.Models;

public partial class Catedratico
{
    public int IdCatedratico { get; set; }

    public string PNombre { get; set; } = null!;

    public string SNombre { get; set; } = null!;

    public string? TNombre { get; set; }

    public string PApellido { get; set; } = null!;

    public string SApellido { get; set; } = null!;

    public DateOnly? FNacimiento { get; set; }

    public int? Telefono { get; set; }

    public DateOnly? FContratacion { get; set; }

    public string? Direccion { get; set; }

    public string? Correo { get; set; }

    public decimal? Salario { get; set; }

    /// <summary>
    /// Estado en que se encuentra, Activo o Inactivo
    /// </summary>
    public string Estatus { get; set; } = null!;

    public virtual ICollection<Curso> IdCursos { get; set; } = new List<Curso>();
}
