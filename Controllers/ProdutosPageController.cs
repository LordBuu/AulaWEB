using ExoLanchonetePedido.Data;
using Microsoft.AspNetCore.Mvc;

namespace ExoLanchonetePedido.Controllers;

[Route("produtos")]
public class ProdutosPageController : Controller
{
    private readonly ProdutoRepository _repo;
    public ProdutosPageController(ProdutoRepository repo) => _repo = repo;

    [HttpGet("")]
    public IActionResult Index() => View(_repo.Listar());
}
