using System;
using System.Collections.Generic;

namespace importaModels.Models;

public partial class AuthPerfilUsuario
{
    public int id { get; set; }

    public int? id_perfil { get; set; }

    public int? id_usuario { get; set; }

    public virtual AuthPerfil? id_perfilNavigation { get; set; }

    public virtual AuthUsuario? id_usuarioNavigation { get; set; }
}
