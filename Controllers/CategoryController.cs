using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderSystem.Data;

namespace OrderSystem.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ProductDbContext _dbContext;
        public CategoryController(ProductDbContext dbContext)
        { 
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var categories = _dbContext.Categories
            .Include(c => c.Products) 
            .Select(c => new
            {
                c.Id,
                c.Name,
                ProductCount = c.Products.Count 
            })
            .ToList();

            return View(categories);
        }
    }
}
