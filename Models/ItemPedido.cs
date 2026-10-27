namespace ExoLanchonetePedido.Models;

public class ItemPedido
{
    public int Id { get; set; }
    public int PedidoNumero { get; set; }
    public Pedido Pedido { get; set; } = null!;
    public int ProdutoId { get; set; }
    public Produto Produto { get; set; } = null!;
    public int Quantidade { get; set; }

    public decimal SubTotal => Produto.Preco * Quantidade;

    private ItemPedido() { }

    public ItemPedido(Produto produto, int quantidade)
    {
        Produto = produto;
        ProdutoId = produto.Id;
        Quantidade = quantidade;
    }
}
