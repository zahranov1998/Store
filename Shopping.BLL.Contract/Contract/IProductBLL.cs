using Shopping.DAL.Contract.Models;

namespace Shopping.BLL.Contract.Contract;

public interface IProductBLL
{
    Task<List<Product>> GetProduct(int id);
}