using Market.Models;
using Microsoft.AspNetCore.Mvc;
using Shopping.BLL.Contract.Contract;
using Shopping.DAL.Contract.Models;
using System.Diagnostics;

namespace Market.Controllers;

public class HomeController : Controller
{
    private static List<Category> _categories;

    private static int _categoryId;

    private readonly ICategoryBLL _categoryBLL;
    private readonly IProductBLL _productBLL;
    private readonly ILogger<HomeController> _logger;
    private readonly ICartBLL _cartBLL;
    private readonly IOrderBLL _orderBLL;

    public HomeController(ILogger<HomeController> logger, ICategoryBLL categoryBLL, IProductBLL productBLL, ICartBLL cartBLL, IOrderBLL orderBLL)
    {
        _logger = logger;
        _categoryBLL = categoryBLL;
        _productBLL = productBLL;
        _cartBLL = cartBLL;
        _orderBLL = orderBLL;
    }

    public async Task<IActionResult> Index()
    {
        _categories = await _categoryBLL.GetCategories();

        ViewBag.Categories = _categories;

        return View(_categories);
    }

    public async Task<IActionResult> GetProducts(int categoryId)
    {
        _categoryId = categoryId;

        var productCategory = await _categoryBLL.GetProducts(categoryId);

        var categories = await _categoryBLL.GetCategories();

        ViewBag.Categories = _categories;

        return View("Index", categories);
    }

    [HttpPost]
    public async Task<IActionResult> AddToCart(ProductDTO productDTO)
    {
        await _cartBLL.AddProduct(productDTO.ProductId);

        var productCategory = await _categoryBLL.GetProducts(_categoryId);

        var categories = (await _categoryBLL.GetCategories()).Select(x => new Category { Id = x.Id, Name = x.Name }).ToList();

        var category = categories.Where(x => x.Id == _categoryId).SingleOrDefault();

        category.Products = productCategory.Products.OrderBy(x => x.Id).ToList();

        ViewBag.Categories = _categories;

        return View("Index", categories);
    }

    public async Task<IActionResult> AddToCartFromCart(ProductDTO productDTO)
    {
        await _cartBLL.AddProduct(productDTO.ProductId);

        var cart = await _cartBLL.GetCart();

        ViewBag.Categories = _categories;

        return View("Cart", cart);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteFromCart(ProductDTO productDTO)
    {
        var cart = await _cartBLL.DeleteProduct(productDTO.ProductId);

        ViewBag.Categories = _categories;

        return View("Cart", cart);
    }


    [HttpPost]
    public async Task<IActionResult> AddToOrder()
    {
        var cartExist = await _orderBLL.AddToOrder();

        if (cartExist == false)
        {
            ViewBag.Message = "There Are No Products In The Cart";
        }
        else
        {
            await _cartBLL.DeleteAllProducts();

            ViewBag.Message = "Your order has been successfully registered";
        }

        var cart = await _cartBLL.GetCart();

        ViewBag.Categories = _categories;

        return View("Cart", cart);
    }


    public async Task<IActionResult> Cart()
    {
        var cart = await _cartBLL.GetCart();

        ViewBag.Categories = _categories;

        return View(cart);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

public class ProductDTO
{
    public int ProductId { get; set; }
}