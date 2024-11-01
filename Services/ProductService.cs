using Microsoft.EntityFrameworkCore;
using OrderSystem.Data;
using OrderSystem.Models;

namespace OrderSystem.Services
{
    public class ProductService
    {
        private readonly ProductDbContext _dbContext;
        public ProductService(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> GetProductsByCategory(int categoryId)
        {
            return _dbContext.Products.Where(p => p.CategoryId == categoryId);
        }

        public IEnumerable<Product> GetProductsSorted(string sortField) =>
            _dbContext.Products.OrderBy(p => EF.Property<object>(p, sortField)).ToList();

        public IEnumerable<Product> SearchProducts(string searchTerm) =>
            _dbContext.Products.Where(p => p.Name.Contains(searchTerm)).ToList();
    }
}
