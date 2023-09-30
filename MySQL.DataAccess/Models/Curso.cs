using System;
using System.Collections.Generic;

namespace MySQL.DataAccess.Models;

public partial class Curso
{
    public int IdCurso { get; set; }


    public string NCurso { get; set; } = null!;

    public int? CantAlumno { get; set; }

    public string Seccion { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int? IdGrado { get; set; }

    public string Status { get; set; } = null!;

    public virtual Grado? IdGradoNavigation { get; set; }

    public virtual ICollection<Notum> Nota { get; set; } = new List<Notum>();

    public virtual ICollection<Catedratico> IdCatedraticos { get; set; } = new List<Catedratico>();
}
