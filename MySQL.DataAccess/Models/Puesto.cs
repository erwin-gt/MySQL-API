using System;
using System.Collections.Generic;

namespace MySQL.DataAccess.Models;

public partial class Puesto
{
    public int IdRol { get; set; }

    public string? Rol { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Administracion> Administracions { get; set; } = new List<Administracion>();
}
