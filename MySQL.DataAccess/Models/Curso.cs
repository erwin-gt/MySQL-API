using System;
using System.Collections.Generic;

namespace MySQL.DataAccess.Models;

/// <summary>
/// Cursos Creados
/// </summary>
public partial class Curso
{
    public int IdCurso { get; set; }

    /// <summary>
    /// Nombre del Curso
    /// </summary>
    public string NCurso { get; set; } = null!;

    /// <summary>
    /// Cantidad de Estudiantes registrados al curso
    /// </summary>
    public int? CantAlumno { get; set; }

    public string Seccion { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int? IdGrado { get; set; }

    /// <summary>
    /// Estado el cual se encuentra, Activo, Inactivo o Pendiente
    /// </summary>
    public string Status { get; set; } = null!;

    public virtual Grado? IdGradoNavigation { get; set; }

    public virtual ICollection<Notum> Nota { get; set; } = new List<Notum>();

    public virtual ICollection<Catedratico> IdCatedraticos { get; set; } = new List<Catedratico>();
}
