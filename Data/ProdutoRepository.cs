using ExoLanchonetePedido.Models;
using Microsoft.EntityFrameworkCore;

namespace ExoLanchonetePedido.Data;

public class ProdutoRepository
{
    private readonly AppDbContext _context;

    public ProdutoRepository(AppDbContext context) => _context = context;

    public Produto? BuscaPorId(int id) => _context.Produtos.Find(id);

    public List<Produto> Listar() => _context.Produtos.OrderBy(p => p.Id).ToList();
}
