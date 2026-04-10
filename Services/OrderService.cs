using EcommerceMVC.Models;

namespace EcommerceMVC.Services
{
    public class OrderService
    {
        private readonly List<Order> _orders = new List<Order>();

        public void PlaceOrder(Order order)
        {
            _orders.Add(order);
        }

        public IEnumerable<Order> GetAllOrders() => _orders;
    }
}