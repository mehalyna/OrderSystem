using Microsoft.AspNetCore.Mvc;
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
            var categories = _dbContext.Categories.ToList();
            return View(categories);
        }
    }
}
