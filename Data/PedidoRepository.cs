using ExoLanchonetePedido.Models;
using Microsoft.EntityFrameworkCore;

namespace ExoLanchonetePedido.Data;

public class PedidoRepository
{
    private readonly AppDbContext _context;

    public PedidoRepository(AppDbContext context) => _context = context;

    public void Adicionar(Pedido pedido)
    {
        _context.Pedidos.Add(pedido);
        _context.SaveChanges();
    }

    public Pedido? BuscarPorNumero(int numero) => _context.Pedidos
        .Include(p => p.Entregador)
        .Include(p => p.Itens)
            .ThenInclude(i => i.Produto)
        .FirstOrDefault(p => p.Numero == numero);

    public List<Pedido> Listar() => _context.Pedidos
        .Include(p => p.Entregador)
        .Include(p => p.Itens)
            .ThenInclude(i => i.Produto)
        .OrderBy(p => p.Numero)
        .ToList();

    public void Salvar() => _context.SaveChanges();
}
