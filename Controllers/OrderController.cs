using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public IActionResult CreateOrder(int productId, int quantity)
        {
            var product = _dbContext.Products.Find(productId);
            if (product == null) return NotFound();

            var order = new Order
            {
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                OrderDate = DateTime.Now,
                Items = new List<OrderItem>
            {
                new OrderItem { ProductId = productId, Quantity = quantity }
            }
            };

            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();

            return Ok(order);
        }
    }

}
