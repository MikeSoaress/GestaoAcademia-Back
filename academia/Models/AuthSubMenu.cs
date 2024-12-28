using System;
using System.Collections.Generic;

namespace academia.Models;

public partial class AuthSubMenu
{
    public int id { get; set; }

    public int? id_menu { get; set; }

    public string? chr_url { get; set; }

    public int? int_ordem { get; set; }

    public virtual AuthMenu? id_menuNavigation { get; set; }
}
