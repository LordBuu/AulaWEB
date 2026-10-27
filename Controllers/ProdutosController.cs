using ExoLanchonetePedido.Data;
using Microsoft.AspNetCore.Mvc;

namespace ExoLanchonetePedido.Controllers;

[ApiController]
[Route("api/produtos")]
public class ProdutosController : ControllerBase
{
    private readonly ProdutoRepository _repository;

    public ProdutosController(ProdutoRepository repository) => _repository = repository;

    [HttpGet]
    public IActionResult Get() => Ok(_repository.Listar());

    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        var produto = _repository.BuscaPorId(id);
        return produto is null ? NotFound(new { mensagem = "Produto não encontrado." }) : Ok(produto);
    }
}
