using System;
using System.Collections.Generic;

namespace MySQL.DataAccess.Models;

public partial class Notum
{
    public int IdNota { get; set; }

    public int Nota { get; set; }

    public string? Descripcion { get; set; }

    public int? IdCurso { get; set; }

    public virtual Curso? IdCursoNavigation { get; set; }
}
