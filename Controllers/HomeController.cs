using ExoLanchonetePedido.Data;
using ExoLanchonetePedido.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExoLanchonetePedido.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _db;
    public HomeController(AppDbContext db) => _db = db;
    public IActionResult Index()
    {
        var pedidos = _db.Pedidos.Include(p => p.Itens).ThenInclude(i => i.Produto).Include(p => p.Entregador)
            .OrderByDescending(p => p.Numero).Take(6).ToList();
        var vm = new DashboardViewModel
        {
            TotalPedidos = _db.Pedidos.Count(),
            PedidosAbertos = _db.Pedidos.Count(p => !p.Fechado),
            Produtos = _db.Produtos.Count(),
            Faturamento = _db.Pedidos.Include(p => p.Itens).ThenInclude(i => i.Produto).Where(p => p.Fechado).AsEnumerable().Sum(p => p.Total),
            PedidosRecentes = pedidos
        };
        return View(vm);
    }
}
