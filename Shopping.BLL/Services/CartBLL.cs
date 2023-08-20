using Shopping.BLL.Contract.Contract;
using Shopping.DAL.Contract.Contract;
using Shopping.DAL.Contract.Models;

namespace Shopping.BLL.Services;

public class CartBLL : ICartBLL
{
    private readonly ICartRepository _cartRepository;
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CartBLL(ICartRepository cartRepository, IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _cartRepository = cartRepository;
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task AddProduct(int id)
    {
        var product = await _productRepository.Get(id);

        var cart = await _cartRepository.Get(1);

        var productItem = cart.ProductItems.Where(x => x.Product != null && x.Product.Id == id).FirstOrDefault();

        if (productItem is null)
        {
            productItem = new ProductItem() { Product = product, Count = 1 };

            cart.ProductItems.Add(productItem);
        }
        else
        {
            productItem.Count++;
        }

        await _unitOfWork.Commit();
    }

    public async Task DeleteAllProducts()
    {
        var cart = await _cartRepository.Get(1);

        cart.ProductItems.Clear();

        await _unitOfWork.Commit();
    }

    public async Task<Cart> DeleteProduct(int id)
    {
        var product = await _productRepository.Get(id);

        var cart = await _cartRepository.Get(1);

        var productItem = cart.ProductItems.Where(x => x.Product.Id == id).FirstOrDefault();

        if (productItem.Count > 1)
        {
            productItem.Count--;
        }
        else
        {
            cart.ProductItems.Remove(productItem);
        }

        await _unitOfWork.Commit();

        return cart;
    }

    public async Task<Cart> GetCart()
    {
        var cart = await _cartRepository.GetCart();

        return cart;
    }
}