using PFLogistcs.Models;

namespace PFLogistcs.Repositories.Interfaces
{
    public interface IProductRepository
    {
         Task<Product[]> GetAllProductsAsync();
         Task<Product[]> GetAllProductsByCategory(string description);
         Task<Product> GetProductByIdAsync(int productId);
    }
}