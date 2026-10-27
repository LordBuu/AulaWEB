using ExoLanchonetePedido.Data;
using ExoLanchonetePedido.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExoLanchonetePedido.Controllers;

[Route("pedidos")]
public class PedidosPageController : Controller
{
    private readonly PedidoRepository _repo;
    private readonly PedidoService _service;
    public PedidosPageController(PedidoRepository repo, PedidoService service) { _repo = repo; _service = service; }

    [HttpGet("")]
    public IActionResult Index() => View(_repo.Listar().OrderByDescending(p => p.Numero).ToList());

    [HttpGet("novo")]
    public IActionResult Novo() => View(_repo.Listar().FirstOrDefault());

    [HttpPost("novo")]
    [ValidateAntiForgeryToken]
    public IActionResult NovoPost()
    {
        var pedido = _service.Abrir();
        return RedirectToAction(nameof(Detalhes), new { numero = pedido.Numero });
    }

    [HttpGet("{numero:int}")]
    public IActionResult Detalhes(int numero)
    {
        try { return View(_service.Buscar(numero)); }
        catch (KeyNotFoundException) { return NotFound(); }
    }

    [HttpPost("{numero:int}/item")]
    [ValidateAntiForgeryToken]
    public IActionResult Item(int numero, int produtoId, int quantidade)
    {
        try { _service.AdicionarItem(numero, produtoId, quantidade); }
        catch (Exception ex) { TempData["Erro"] = ex.Message; }
        return RedirectToAction(nameof(Detalhes), new { numero });
    }

    [HttpPost("{numero:int}/entregador")]
    [ValidateAntiForgeryToken]
    public IActionResult Entregador(int numero, string nome)
    {
        try { _service.DefinirEntregador(numero, nome); }
        catch (Exception ex) { TempData["Erro"] = ex.Message; }
        return RedirectToAction(nameof(Detalhes), new { numero });
    }

    [HttpPost("{numero:int}/fechar")]
    [ValidateAntiForgeryToken]
    public IActionResult Fechar(int numero)
    {
        try { _service.Fechar(numero); }
        catch (Exception ex) { TempData["Erro"] = ex.Message; }
        return RedirectToAction(nameof(Detalhes), new { numero });
    }
}
