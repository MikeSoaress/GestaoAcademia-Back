using System;
using System.Collections.Generic;

namespace importaModels.Models;

public partial class Endereco
{
    public int id { get; set; }

    public int? id_pessoa { get; set; }

    public string? chr_logradouro { get; set; }

    public string? chr_numero { get; set; }

    public string? chr_bairro { get; set; }

    public string? chr_cidade { get; set; }

    public string? chr_estado { get; set; }

    public string? chr_cep { get; set; }

    public virtual Pessoa? id_pessoaNavigation { get; set; }
}
