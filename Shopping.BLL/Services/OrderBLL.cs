using Shopping.BLL.Contract.Contract;
using Shopping.DAL.Contract.Contract;
using Shopping.DAL.Contract.Models;

namespace Shopping.BLL.Services;

public class OrderBLL : IOrderBLL
{
    private readonly ICartRepository _cartRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;

    public OrderBLL(ICartRepository cartRepository, IOrderRepository orderRepository, IUnitOfWork unitOfWork)
    {
        _cartRepository = cartRepository;
        _orderRepository = orderRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> AddToOrder()
    {
        var cart = await _cartRepository.GetCart();

        if (cart.ProductItems.Count == 0)
        {
            return false;
        }

        var order = new Order() { Date = DateTime.Now };

        order.OrderItems = new List<OrderItem>();

        foreach (var item in cart.ProductItems)
        {
            var orderItem = new OrderItem() { Product = item.Product, Count = 1 };

            order.OrderItems.Add(orderItem);
        }

        _orderRepository.Add(order);

        await _unitOfWork.Commit();

        return true;
    }
}