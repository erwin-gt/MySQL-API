using System;
using System.Collections.Generic;

namespace MySQL.DataAccess.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Usuario1 { get; set; }

    public string? Correo { get; set; }

    /// <summary>
    /// Fecha Cracion del Usuario
    /// </summary>
    public DateOnly? FCreacion { get; set; }

    public string? Clave { get; set; }

    public string TipoUsuario { get; set; } = null!;

    public virtual ICollection<HitorialRefreshToken> HitorialRefreshTokens { get; set; } = new List<HitorialRefreshToken>();
}
