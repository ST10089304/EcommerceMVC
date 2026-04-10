using EcommerceMVC.Models;
using EcommerceMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMVC.Controllers
{
    public class ShopController : Controller
    {
        private readonly ProductRepository _productRepository;
        private readonly OrderService _orderService;
        private static List<CartItem> _cart = new List<CartItem>();

        public ShopController(ProductRepository productRepository, OrderService orderService)
        {
            _productRepository = productRepository;
            _orderService = orderService;
        }

        public IActionResult Home()
        {
            var featured = _productRepository.GetAll().Take(4);
            return View(featured);
        }

        public IActionResult Index()
        {
            var products = _productRepository.GetAll();
            return View(products);
        }

        [HttpPost]
        public IActionResult AddToCart(int productId)
        {
            var product = _productRepository.GetById(productId);
            if (product != null)
            {
                var cartItem = _cart.FirstOrDefault(c => c.Product.Id == productId);
                if (cartItem != null)
                    cartItem.Quantity++;
                else
                    _cart.Add(new CartItem { Product = product, Quantity = 1 });
            }
            return RedirectToAction("Cart");
        }

        public IActionResult Cart()
        {
            return View(_cart);
        }

        [HttpPost]
        public IActionResult Checkout()
        {
            if (_cart.Any())
            {
                var order = new Order { Items = new List<CartItem>(_cart) };
                _orderService.PlaceOrder(order);
                _cart.Clear();
                TempData["Message"] = "Order placed successfully!";
            }
            return RedirectToAction("OrderConfirmation");
        }

        public IActionResult OrderConfirmation()
        {
            return View();
        }
    }
}