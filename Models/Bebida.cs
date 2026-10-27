namespace ExoLanchonetePedido.Models;

public class Bebida : Produto
{
    public int VolumeMl { get; set; }

    public Bebida() { }

    public Bebida(int id, string nome, decimal preco, int volumeMl)
        : base(id, nome, preco)
    {
        VolumeMl = volumeMl;
    }
}
