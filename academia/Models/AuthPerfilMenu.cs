using System;
using System.Collections.Generic;

namespace academia.Models;

public partial class AuthPerfilMenu
{
    public int id { get; set; }

    public int? id_perfil_usuario { get; set; }

    public int? id_menu { get; set; }

    public virtual AuthMenu? id_menuNavigation { get; set; }

    public virtual AuthPerfil? id_perfil_usuarioNavigation { get; set; }
}
