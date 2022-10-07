using System.Collections.Generic;
using System.Linq;
using API_Folhas.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Folhas.Controllers
{
  [ApiController]
  [Route("api/folha")]
  public class FolhaController : ControllerBase
  {
    private readonly DataContext _context;
    public FolhaController(DataContext context) =>
        _context = context;

    private static List<FolhaPagamento> folhas = new List<FolhaPagamento>();

    // POST: /api/folha/cadastrar
    [Route("cadastrar")]
    [HttpPost]
    public IActionResult Cadastrar([FromBody] FolhaPagamento folha)
    {
      //Relacionamento da classe FuncionarioController.Funcionario que recebe funcionario
      //FuncionarioController.Funcionario = funcionario;
      //if (funcionario != null) depois de relacionar as classes.
      if (folha != null)
      {
        _context.Folhas.Add(folha);
        _context.SaveChanges();
        return Created("", folha);
      }
      return NotFound();
    }

    // GET: /api/folha/listar
    [Route("listar")]
    [HttpGet]
    // public IActionResult Listar([FromBody] FolhaPagamento folha)
    // {
    //   //if (funcionario != null) depois de relacionar as classes
    //   if (folha != null)
    //   {
    public IActionResult Listar() =>
    Ok(_context.Folhas.ToList());
    //   }
    //   return NotFound();
    // }

    // GET: /api/folha/buscar/{cpf}/{mes}/{ano}
    [Route("buscar/{cpf}/{mes}/{ano}")]
    [HttpGet]
    public IActionResult Buscar([FromRoute] string cpf, int mes, int ano)
    {
      //Expressão lambda
      Funcionario funcionario = _context.Funcionarios.All
      (
        f => f.Cpf.Equals(cpf),
        m => m.Mes.Equals(mes),
        a => a.Ano.Equals(ano)
      );
      //IF ternário
      return funcionario != null ? Ok(funcionario) : NotFound();
    }

    // GET: /api/folha/filtrar/{mes}/{ano}
    [Route("filtrar/{mes}/{ano}")]
    [HttpGet]
    public IActionResult Filtrar([FromRoute] int mes, int ano)
    {
      //Expressão lambda
      Funcionario funcionario = _context.Funcionarios.All
      (
        m => m.Mes.Equals(mes),
        a => a.Ano.Equals(ano)
      );
      //IF ternário
      return funcionario != null ? Ok(funcionario) : NotFound();
    }
  }
}