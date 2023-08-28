using Microsoft.EntityFrameworkCore;
using SimpleGraphQL.Models;

namespace SimpleGraphQL;

public class ProductsDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=products.db");
        optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
    }

    public DbSet<Product> Products { get; set; }
    
    public DbSet<Manufacturer> Manufacturers { get; set; }
}