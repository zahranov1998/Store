namespace Shopping.BLL.Contract.Contract;

public interface IOrderBLL
{
    Task<bool> AddToOrder();
}
