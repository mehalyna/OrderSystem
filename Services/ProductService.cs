using Microsoft.EntityFrameworkCore;
using OrderSystem.Data;
using OrderSystem.Models;

namespace OrderSystem.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductDbContext _dbContext;
        public ProductService(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> SearchProductsByName(string substring)
        {
            if (string.IsNullOrWhiteSpace(substring))
            {
                return _dbContext.Products.Include(p => p.Category).ToList(); 
            }

            return _dbContext.Products
                    .Include(p => p.Category)
                    .AsEnumerable() 
                    .Where(p => p.Name.Contains(substring, System.StringComparison.OrdinalIgnoreCase))
                    .ToList();
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
