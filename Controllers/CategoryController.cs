using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderSystem.Data;
using OrderSystem.Services;

namespace OrderSystem.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ProductDbContext _dbContext;
       

        public CategoryController(ProductDbContext dbContext)
        { 
            _dbContext = dbContext;
            
        }

        public IActionResult Index(string sortOrder)
        {
            // Set up the current sort order for toggling
            ViewBag.NameSortParam = sortOrder == "name_desc" ? "name_asc" : "name_desc";

            // Fetch categories and include the count of associated products
            var categories = _dbContext.Categories
                .Include(c => c.Products)
                .Select(c => new
                {
                    c.Id,
                    c.Name,
                    ProductCount = c.Products.Count
                });

            // Apply sorting based on the sortOrder parameter
            categories = sortOrder switch
            {
                "name_desc" => categories.OrderByDescending(c => c.Name),
                _ => categories.OrderBy(c => c.Name), // Default to ascending by name
            };

            return View(categories.ToList());
        }
    }
}
