using Shopping.DAL.Contract.Models;

namespace Shopping.DAL.Contract.Contract;

public interface IOrderRepository
{
    void Add(Order order);
}