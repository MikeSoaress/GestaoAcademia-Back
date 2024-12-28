using System;
using System.Collections.Generic;

namespace importaModels.Models;

public partial class AuthPerfil
{
    public int id { get; set; }

    public string? chr_descricao { get; set; }

    public virtual ICollection<AuthPerfilMenu> AuthPerfilMenus { get; set; } = new List<AuthPerfilMenu>();

    public virtual ICollection<AuthPerfilUsuario> AuthPerfilUsuarios { get; set; } = new List<AuthPerfilUsuario>();
}
