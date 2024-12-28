using System;
using System.Collections.Generic;

namespace academia.Models;

public partial class AuthMenu
{
    public int id { get; set; }

    public string? chr_legenda { get; set; }

    public string? chr_url { get; set; }

    public string? chr_path_icone { get; set; }

    public int? int_ordem { get; set; }

    public virtual ICollection<AuthPerfilMenu> AuthPerfilMenus { get; set; } = new List<AuthPerfilMenu>();

    public virtual ICollection<AuthSubMenu> AuthSubMenus { get; set; } = new List<AuthSubMenu>();
}
