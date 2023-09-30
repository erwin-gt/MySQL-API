using System;
using System.Collections.Generic;

namespace MySQL.DataAccess.Models;

public partial class Inscripcion
{
    public int IdInscripcion { get; set; }
    public DateOnly FIncripcion { get; set; }

    public int? IdCarrera { get; set; }

    public int? IdEstudiante { get; set; }

    public int? IdAdmin { get; set; }

    public virtual Administracion? IdAdminNavigation { get; set; }

    public virtual Carrera? IdCarreraNavigation { get; set; }

    public virtual Estudiante? IdEstudianteNavigation { get; set; }
}
