using Shopping.DAL.Contract.Contract;
using Shopping.DAL.Contract.Models;
using Shopping.DAL.DbContexts;

namespace Shopping.DAL.Repositories;

public class OrderRepository : IOrderRepository
{

    private readonly EFDbContext _dbContext;

    public OrderRepository(EFDbContext eFDbContext)
    {
        _dbContext = eFDbContext;
    }

    public void Add(Order order)
    {
        _dbContext.Orders.Add(order);
    }
}