using Shopping.BLL.Contract.Contract;
using Shopping.DAL.Contract.Contract;
using Shopping.DAL.Contract.Models;

namespace Shopping.BLL.Services;

public class ProductBLL : IProductBLL
{
    private readonly IProductRepository _productDAL;

    public ProductBLL(IProductRepository productRepository)
    {
        _productDAL = productRepository;
    }

    public async Task<List<Product>> GetProduct(int id)
    {
        return await _productDAL.Select(id);
    }
}