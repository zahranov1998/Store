using Shopping.DAL.Contract.Models;

namespace Shopping.DAL.Contract.Contract;

public interface IProductRepository
{
    Task<List<Product>> Select(int id);
    Task<Product?> Get(int id);
}