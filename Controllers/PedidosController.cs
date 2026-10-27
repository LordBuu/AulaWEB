using ExoLanchonetePedido.Data;
using ExoLanchonetePedido.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExoLanchonetePedido.Controllers;

[ApiController]
[Route("api/pedidos")]
public class PedidosController : ControllerBase
{
    private readonly PedidoService _service;
    private readonly PedidoRepository _repository;

    public PedidosController(PedidoService service, PedidoRepository repository)
    {
        _service = service;
        _repository = repository;
    }

    [HttpPost]
    public IActionResult Abrir()
    {
        var pedido = _service.Abrir();
        return CreatedAtAction(nameof(Get), new { numero = pedido.Numero }, pedido);
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_repository.Listar());

    [HttpGet("{numero:int}")]
    public IActionResult Get(int numero)
    {
        try { return Ok(_service.Buscar(numero)); }
        catch (KeyNotFoundException ex) { return NotFound(new { mensagem = ex.Message }); }
    }

    [HttpPost("{numero:int}/itens")]
    public IActionResult AdicionarItem(int numero, [FromBody] AdicionarItemRequest request)
    {
        try
        {
            _service.AdicionarItem(numero, request.ProdutoId, request.Quantidade);
            return Ok(_service.Buscar(numero));
        }
        catch (KeyNotFoundException ex) { return NotFound(new { mensagem = ex.Message }); }
        catch (ArgumentException ex) { return BadRequest(new { mensagem = ex.Message }); }
        catch (InvalidOperationException ex) { return BadRequest(new { mensagem = ex.Message }); }
    }

    [HttpPut("{numero:int}/entregador")]
    public IActionResult DefinirEntregador(int numero, [FromBody] EntregadorRequest request)
    {
        try
        {
            _service.DefinirEntregador(numero, request.Nome);
            return Ok(_service.Buscar(numero));
        }
        catch (KeyNotFoundException ex) { return NotFound(new { mensagem = ex.Message }); }
        catch (InvalidOperationException ex) { return BadRequest(new { mensagem = ex.Message }); }
    }

    [HttpPut("{numero:int}/fechar")]
    public IActionResult Fechar(int numero)
    {
        try
        {
            _service.Fechar(numero);
            return Ok(_service.Buscar(numero));
        }
        catch (KeyNotFoundException ex) { return NotFound(new { mensagem = ex.Message }); }
        catch (InvalidOperationException ex) { return BadRequest(new { mensagem = ex.Message }); }
    }
}

public record AdicionarItemRequest(int ProdutoId, int Quantidade);
public record EntregadorRequest(string Nome);
