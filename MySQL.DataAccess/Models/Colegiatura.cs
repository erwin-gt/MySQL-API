using System;
using System.Collections.Generic;

namespace MySQL.DataAccess.Models;

public partial class Colegiatura
{
    public int IdColegiatura { get; set; }

    public decimal Costo { get; set; }

    public string? Descripcion { get; set; }

    public int? IdCarrera { get; set; }

    public decimal? Mora { get; set; }

    public virtual Carrera? IdCarreraNavigation { get; set; }
}
