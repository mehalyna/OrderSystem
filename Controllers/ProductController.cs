using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrderSystem.Data;
using OrderSystem.Models;
using OrderSystem.Services;

namespace OrderSystem.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductDbContext _dbContext;
        private readonly IProductService _productService;

        public ProductController(ProductDbContext dbContext, IProductService productService)
        {
            _dbContext = dbContext;
            _productService = productService;
        }

        public IActionResult Index(string searchString)
        {
            IEnumerable<Product> products;

            if (!string.IsNullOrEmpty(searchString))
            {
                products = _productService.SearchProductsByName(searchString);
                ViewBag.SearchString = searchString; 
            }
            else
            {
                products = _dbContext.Products.Include(p => p.Category).ToList();
            }

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
