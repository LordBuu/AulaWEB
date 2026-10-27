using System.ComponentModel.DataAnnotations;

namespace ExoLanchonetePedido.Models;

public class Pedido
{
    [Key]
    public int Numero { get; set; }
    public bool Fechado { get; set; }
    public int? EntregadorId { get; set; }
    public Entregador? Entregador { get; set; }
    public List<ItemPedido> Itens { get; set; } = new();

    public decimal Total => Itens.Sum(i => i.SubTotal);

    public Pedido() { }

    public Pedido(int numero)
    {
        Numero = numero;
    }

    public void AdicionarItem(Produto produto, int quantidade)
    {
        if (Fechado) throw new InvalidOperationException("O pedido já está fechado.");
        if (quantidade <= 0) throw new ArgumentException("A quantidade deve ser maior que zero.");
        Itens.Add(new ItemPedido(produto, quantidade));
    }

    public void DefinirEntregador(Entregador entregador)
    {
        if (Fechado) throw new InvalidOperationException("O pedido já está fechado.");
        Entregador = entregador;
    }

    public void Fechar()
    {
        if (Itens.Count == 0) throw new InvalidOperationException("Não é possível fechar um pedido sem itens.");
        Fechado = true;
    }
}
