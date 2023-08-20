using Shopping.DAL.Contract.Models;

namespace Shopping.BLL.Contract.Contract;

public interface ICategoryBLL
{
    Task<List<Category>> GetCategories();
    Task<Category> GetProducts(int id);
}