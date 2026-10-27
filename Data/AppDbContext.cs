using ExoLanchonetePedido.Models;
using Microsoft.EntityFrameworkCore;

namespace ExoLanchonetePedido.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Pedido> Pedidos => Set<Pedido>();
    public DbSet<Produto> Produtos => Set<Produto>();
    public DbSet<ItemPedido> ItensPedido => Set<ItemPedido>();
    public DbSet<Entregador> Entregadores => Set<Entregador>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Produto>()
    .ToTable("Produtos");

        modelBuilder.Entity<Bebida>()
            .HasBaseType<Produto>();

        modelBuilder.Entity<Lanche>()
        .HasBaseType<Produto>();
        modelBuilder.Entity<Pedido>()
            .HasKey(p => p.Numero);

        modelBuilder.Entity<Pedido>()
            .Property(p => p.Numero)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Produto>()
            .Property(p => p.Preco)
            .HasPrecision(10, 2);

        modelBuilder.Entity<Pedido>()
            .HasOne(p => p.Entregador)
            .WithMany()
            .HasForeignKey(p => p.EntregadorId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<ItemPedido>()
            .HasOne(i => i.Pedido)
            .WithMany(p => p.Itens)
            .HasForeignKey(i => i.PedidoNumero)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ItemPedido>()
            .HasOne(i => i.Produto)
            .WithMany()
            .HasForeignKey(i => i.ProdutoId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Bebida>().HasData(
            new { Id = 1, Nome = "Coca-Cola", Preco = 5.00m, VolumeMl = 350 },
            new { Id = 2, Nome = "Guaraná", Preco = 4.50m, VolumeMl = 350 });

        modelBuilder.Entity<Lanche>().HasData(
            new { Id = 3, Nome = "X-Burguer", Preco = 10.00m, Vegetariano = false },
            new { Id = 4, Nome = "X-Salada", Preco = 12.00m, Vegetariano = false },
            new { Id = 5, Nome = "Veggie Burger", Preco = 15.00m, Vegetariano = true });
    }
}
