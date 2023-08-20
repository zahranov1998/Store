using Microsoft.EntityFrameworkCore;
using Shopping.DAL.Contract.Contract;
using Shopping.DAL.Contract.Models;
using Shopping.DAL.DbContexts;

namespace Shopping.DAL.Repositories;

public class CartRepository : ICartRepository
{
    private readonly EFDbContext _dbContext;

    public CartRepository(EFDbContext eFDbContext)
    {
        _dbContext = eFDbContext;
    }

    public void Insert(Cart cart)
    {
        _dbContext.Carts.Add(cart);
    }

    public async Task<Cart?> Get(int id)
    {
        return await _dbContext.Carts.Where(c => c.UserId == id).Include(c => c.ProductItems).ThenInclude(p => p.Product).SingleOrDefaultAsync();
    }

    public async Task<Cart?> GetCart()
    {
        return await _dbContext.Carts.Where(c => c.Id == 1).Include(c => c.ProductItems).ThenInclude(c => c.Product).SingleOrDefaultAsync();
    }
}