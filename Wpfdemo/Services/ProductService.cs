using Microsoft.EntityFrameworkCore;
using Wpfdemo.Data;
using Wpfdemo.Models;

namespace Wpfdemo.Services;

public class ProductService
{
    private readonly IDbContextFactory<AppDbContext> _dbFactory;

    public ProductService(IDbContextFactory<AppDbContext> dbFactory)
    {
        _dbFactory = dbFactory;
    }

    public async Task<List<Product>> GetAllAsync()
    {
        await using var db = await _dbFactory.CreateDbContextAsync();

        return await db.Products
            .AsNoTracking()
            .OrderBy(p => p.Name)
            .ToListAsync();
    }

    public async Task AddAsync(string name, decimal price)
    {
        await using var db = await _dbFactory.CreateDbContextAsync();

        var product = new Product
        {
            Name = name,
            Price = price
        };

        db.Products.Add(product);

        await db.SaveChangesAsync();
    }
}