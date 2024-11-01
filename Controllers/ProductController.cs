using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderSystem.Data;

namespace OrderSystem.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductDbContext _dbContext;
        public ProductController(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var products = _dbContext.Products.Include(p => p.Category).ToList();
            return View(products);
        }

    }
}
