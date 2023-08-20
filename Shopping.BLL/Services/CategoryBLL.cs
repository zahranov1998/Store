using Shopping.BLL.Contract.Contract;
using Shopping.DAL.Contract.Contract;
using Shopping.DAL.Contract.Models;

namespace Shopping.BLL.Services;

public class CategoryBLL : Contract.Contract.ICategoryBLL
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryBLL(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<List<Category>> GetCategories()
    {
        return await _categoryRepository.Select();
    }

    public async Task<Category?> GetProducts(int id)
    {
        return await _categoryRepository.GetProductsOfCategory(id);
    }
}