using System;
using System.Collections.Generic;

namespace MySQL.DataAccess.Models;

public partial class Grado
{
    public int IdGrado { get; set; }

    public string GradoN { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int? IdCarrera { get; set; }

    public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();

    public virtual Carrera? IdCarreraNavigation { get; set; }
}
