using System;
using System.Collections.Generic;

namespace importaModels.Models;

public partial class AuthUsuario
{
    public int id { get; set; }

    public int? id_pessoa { get; set; }

    public string? chr_login { get; set; }

    public string? chr_senha_hash { get; set; }

    public virtual ICollection<AuthPerfilUsuario> AuthPerfilUsuarios { get; set; } = new List<AuthPerfilUsuario>();

    public virtual Pessoa? id_pessoaNavigation { get; set; }
}
