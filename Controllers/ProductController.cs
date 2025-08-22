using Microsoft.AspNetCore.Mvc;
using ProductMvcApp.Models;
using System.Diagnostics;

namespace ProductMvcApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
            _logger.LogInformation("ProductController initialized");
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Product Index action called");

            // Sample product data
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", Price = 999.99m, Category = "Electronics", CreatedDate = DateTime.Now.AddDays(-10) },
                new Product { Id = 2, Name = "Coffee Mug", Price = 12.99m, Category = "Kitchen", CreatedDate = DateTime.Now.AddDays(-5) },
                new Product { Id = 3, Name = "Desk Chair", Price = 149.99m, Category = "Furniture", CreatedDate = DateTime.Now.AddDays(-2) }
            };

            return View(products);
        }

        [HttpPost]
        public IActionResult Search(string searchTerm)
        {
            _logger.LogInformation($"Search action called with term: {searchTerm}");

            // In a real application, you would search your database here
            // For now, we'll just redirect back to index
            TempData["SearchMessage"] = $"You searched for: {searchTerm}";
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}