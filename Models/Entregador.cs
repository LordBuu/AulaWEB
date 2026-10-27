namespace ExoLanchonetePedido.Models;

public class Entregador
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;

    public Entregador() { }

    public Entregador(string nome)
    {
        Nome = nome;
    }
}