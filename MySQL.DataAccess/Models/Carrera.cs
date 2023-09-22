using System;
using System.Collections.Generic;

namespace MySQL.DataAccess.Models;

public partial class Carrera
{
    public int IdCarrera { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Colegiatura> Colegiaturas { get; set; } = new List<Colegiatura>();

    public virtual ICollection<Grado> Grados { get; set; } = new List<Grado>();

    public virtual ICollection<Inscripcion> Inscripcions { get; set; } = new List<Inscripcion>();
}
