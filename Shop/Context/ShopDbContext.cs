using Microsoft.EntityFrameworkCore;
using Shop.Entities;

namespace Shop.Context;

public class ShopDbContext:DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=LAPTOP-KBFH69R7;Initial Catalog=Shoppingg;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.products)
            .HasForeignKey(p => p.CategoryId);

        modelBuilder.Entity<Order>()
        .HasMany(o => o.Products)
        .WithMany(p => p.Orders)
        .UsingEntity(j => j.ToTable("OrderProducts"));

    }
}
