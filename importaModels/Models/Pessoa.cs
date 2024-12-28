using System;
using System.Collections.Generic;

namespace importaModels.Models;

public partial class Pessoa
{
    public int id { get; set; }

    public string? chr_nome { get; set; }

    public string? chr_email { get; set; }

    public DateOnly? dt_nascimento { get; set; }

    public string? chr_cpf { get; set; }

    public string? chr_fone { get; set; }

    public string? chr_path_foto { get; set; }

    public virtual ICollection<AuthUsuario> AuthUsuarios { get; set; } = new List<AuthUsuario>();

    public virtual ICollection<Endereco> Enderecos { get; set; } = new List<Endereco>();
}
