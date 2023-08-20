using Microsoft.EntityFrameworkCore;
using Shopping.DAL.Contract.Contract;
using Shopping.DAL.Contract.Models;
using Shopping.DAL.DbContexts;

namespace Shopping.DAL.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly EFDbContext _dbContext;

    public CategoryRepository(EFDbContext eFDbContext)
    {
        _dbContext = eFDbContext;
    }

    public async Task<List<Category>> Select()
    {
        return await _dbContext.Categories.ToListAsync();
    }

    public async Task<Category?> GetById(int id)
    {
        return await _dbContext.Categories.Where(c => c.Id == id).SingleOrDefaultAsync();
    }

    public async Task<Category?> GetProductsOfCategory(int id)
    {
        return await _dbContext.Categories.Include(c => c.Products).Where(c => c.Id == id).SingleOrDefaultAsync();
    }
}