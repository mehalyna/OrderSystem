using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrderSystem.Data;
using OrderSystem.Models;

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

        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_dbContext.Categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Products.Add(product);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(_dbContext.Categories, "Id", "Name");
            return View(product);
        }

        public IActionResult Details(int id)
        {
            var product = _dbContext.Products
                .Include(p => p.Category) // Include related data, if necessary
                .FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }


    }
}
