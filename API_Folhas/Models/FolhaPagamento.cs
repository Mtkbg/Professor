using System;
using System.ComponentModel.DataAnnotations;

namespace API_Folhas.Models
{
  public class FolhaPagamento
  {
    //cadastro
    public int funcionarioId { get; set; }
    public int valorhora { get; set; }
    public int quantidadehoras { get; set; }

    //listar
    public int folhaid { get; set; }
    public int salariobruto { get; set; }
    public int impostorenda { get; set; }
    public int impostoinss { get; set; }
    public int impostofgts { get; set; }
    public int salarioliquido { get; set; }
  }
}