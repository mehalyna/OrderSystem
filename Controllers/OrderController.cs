using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrderSystem.Data;
using OrderSystem.Models;
using System.Security.Claims;

namespace OrderSystem.Controllers
{
    public class OrderController : Controller
    {
        private readonly ProductDbContext _dbContext;

        public OrderController(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Create()
        {
            ViewBag.Products = new SelectList(_dbContext.Products, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Orders.Add(order);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Product");
            }
            ViewBag.Products = new SelectList(_dbContext.Products, "Id", "Name");
            return View(order);
        }

    }

}
