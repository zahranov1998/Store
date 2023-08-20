using Shopping.DAL.Contract.Models;

namespace Shopping.DAL.Contract.Contract;

public interface ICartRepository
{
    void Insert(Cart cart);
    Task<Cart?> Get(int id);
    Task<Cart?> GetCart();
}