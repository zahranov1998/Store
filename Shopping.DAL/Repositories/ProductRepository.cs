using Microsoft.EntityFrameworkCore;
using Shopping.DAL.Contract.Contract;
using Shopping.DAL.Contract.Models;
using Shopping.DAL.DbContexts;

namespace Shopping.DAL.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly EFDbContext _dbContext;

    public ProductRepository(EFDbContext eFDbContext)
    {
        _dbContext = eFDbContext;
    }

    public async Task<List<Product>> Select(int id)
    {
        return await _dbContext.Products.Where(p => p.Category.Id == id).Include(p => p.Category).ToListAsync();
    }

    public async Task<Product?> Get(int id)
    {
        return await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == id);
    }
}