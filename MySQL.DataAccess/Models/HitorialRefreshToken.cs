using System;
using System.Collections.Generic;

namespace MySQL.DataAccess.Models;

public partial class HitorialRefreshToken
{
    public int IdHistorial { get; set; }

    public int? IdUsuario { get; set; }

    public string? Token { get; set; }

    public string? RefreshToken { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaExpiracion { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
