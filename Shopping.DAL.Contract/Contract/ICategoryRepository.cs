using Shopping.DAL.Contract.Models;

namespace Shopping.DAL.Contract.Contract;

public interface ICategoryRepository
{
    Task<List<Category>> Select();
    Task<Category?> GetById(int id);
    Task<Category?> GetProductsOfCategory(int id);
}