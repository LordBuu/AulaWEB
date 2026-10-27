using ExoLanchonetePedido.Models;
namespace ExoLanchonetePedido.ViewModels;
public class DashboardViewModel
{
    public int TotalPedidos { get; set; }
    public int PedidosAbertos { get; set; }
    public int Produtos { get; set; }
    public decimal Faturamento { get; set; }
    public List<Pedido> PedidosRecentes { get; set; } = new();
}
