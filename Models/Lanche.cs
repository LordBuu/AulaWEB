namespace ExoLanchonetePedido.Models;

public class Lanche : Produto
{
    public bool Vegetariano { get; set; }

    public Lanche() { }

    public Lanche(int id, string nome, decimal preco, bool vegetariano)
        : base(id, nome, preco)
    {
        Vegetariano = vegetariano;
    }
}
