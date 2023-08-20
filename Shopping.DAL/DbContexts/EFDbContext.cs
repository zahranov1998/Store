using Microsoft.EntityFrameworkCore;
using Shopping.DAL.Contract.Models;
using Shopping.DAL.Mappings;

namespace Shopping.DAL.DbContexts;

public class EFDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Cart> Carts { get; set; }

    public DbSet<Order> Orders { get; set; }

    public EFDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductMapping).Assembly);
    }
}