using EcommerceMVC.Models;
using System.Text.Json;

namespace EcommerceMVC.Services
{
    public class ProductRepository
    {
        private readonly HttpClient _httpClient;
        private List<Product> _products = new List<Product>();

        public ProductRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
            LoadProducts().Wait();
        }

        private async Task LoadProducts()
        {
            try
            {
                var response = await _httpClient.GetStringAsync("https://dummyjson.com/products?limit=12");
                var json = JsonDocument.Parse(response);
                var productsArray = json.RootElement.GetProperty("products");

                foreach (var item in productsArray.EnumerateArray())
                {
                    _products.Add(new Product
                    {
                        Id = item.GetProperty("id").GetInt32(),
                        Name = item.GetProperty("title").GetString() ?? "",
                        Price = item.GetProperty("price").GetDecimal(),
                        Description = item.GetProperty("description").GetString() ?? "",
                        Category = item.GetProperty("category").GetString() ?? "",
                        Thumbnail = item.GetProperty("thumbnail").GetString() ?? "",
                        Rating = item.GetProperty("rating").GetDouble()
                    });
                }
            }
            catch
            {
                _products = new List<Product>
                {
                    new Product { Id = 1, Name = "Laptop", Price = 18000, Description = "High performance laptop", Category = "electronics", Thumbnail = "", Rating = 4.5 },
                    new Product { Id = 2, Name = "Phone", Price = 9000, Description = "Smartphone", Category = "electronics", Thumbnail = "", Rating = 4.2 },
                    new Product { Id = 3, Name = "Tablet", Price = 5500, Description = "Portable tablet", Category = "electronics", Thumbnail = "", Rating = 4.0 }
                };
            }
        }

        public IEnumerable<Product> GetAll() => _products;
        public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);
    }
}