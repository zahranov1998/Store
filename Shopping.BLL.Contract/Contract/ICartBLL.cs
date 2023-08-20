using Shopping.DAL.Contract.Models;

namespace Shopping.BLL.Contract.Contract;

public interface ICartBLL
{
    public Task AddProduct(int id);
    Task DeleteAllProducts();
    Task<Cart> DeleteProduct(int id);
    Task<Cart> GetCart();
}