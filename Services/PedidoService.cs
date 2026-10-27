using ExoLanchonetePedido.Data;
using ExoLanchonetePedido.Models;

namespace ExoLanchonetePedido.Services;

public class PedidoService
{
    private readonly PedidoRepository _pedidoRepository;
    private readonly ProdutoRepository _produtoRepository;

    public PedidoService(
        PedidoRepository pedidoRepository,
        ProdutoRepository produtoRepository)
    {
        _pedidoRepository = pedidoRepository;
        _produtoRepository = produtoRepository;
    }

    public Pedido Abrir()
    {
        var pedido = new Pedido(0);
        _pedidoRepository.Adicionar(pedido);
        return pedido;
    }

    public Pedido Buscar(int numero)
    {
        return _pedidoRepository.BuscarPorNumero(numero)
            ?? throw new KeyNotFoundException("Pedido não encontrado.");
    }

    public void AdicionarItem(int numero, int produtoId, int quantidade)
    {
        var pedido = Buscar(numero);

        var produto = _produtoRepository.BuscaPorId(produtoId)
            ?? throw new KeyNotFoundException("Produto não encontrado.");

        pedido.AdicionarItem(produto, quantidade);
        _pedidoRepository.Salvar();
    }

    public void DefinirEntregador(int numero, string nome)
    {
        var pedido = Buscar(numero);

        var entregador = new Entregador(nome);
        pedido.DefinirEntregador(entregador);

        _pedidoRepository.Salvar();
    }

    public void Fechar(int numero)
    {
        var pedido = Buscar(numero);

        pedido.Fechar();
        _pedidoRepository.Salvar();
    }
}