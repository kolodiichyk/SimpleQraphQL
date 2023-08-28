using Microsoft.EntityFrameworkCore;
using SimpleGraphQL.Models;

namespace SimpleGraphQL.Schema;

public class Query
{
    public async Task<IReadOnlyList<Product>> GetProducts([Service] ProductsDbContext dbContext)
    {
        return await dbContext.Products
            .Include(p => p.Manufacturer)
            .OrderBy(p => p.Id)
            .ToListAsync();
    }
    
    public Task<Product?> GetProduct([Service] ProductsDbContext dbContext, int id) 
        => dbContext.Products
            .Include(p => p.Manufacturer)
            .FirstOrDefaultAsync(p => p.Id == id);
    
    public async Task<IReadOnlyList<Manufacturer>> GetManufacturers([Service] ProductsDbContext dbContext)
    {
        return await dbContext.Manufacturers
            .Include(m => m.Products)
            .OrderBy(p => p.Id)
            .ToListAsync();
    }
    
    public Task<Manufacturer?> GetManufacturer([Service] ProductsDbContext dbContext, int id) 
        => dbContext.Manufacturers
            .Include(m => m.Products)
            .FirstOrDefaultAsync(p => p.Id == id);
}