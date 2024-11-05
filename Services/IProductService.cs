using global::OrderSystem.Models;


namespace OrderSystem.Services
{
    public interface IProductService
    {
        IEnumerable<Product> SearchProductsByName(string substring);
    }
}

