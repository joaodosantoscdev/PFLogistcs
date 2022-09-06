using PFLogistcs.Models;

namespace PFLogistcs.Services
{
    public interface IProductService 
    {
        Task<Product[]> GetAllProductsAsync();
        Task<Product[]> GetAllProductsByCategory(string description);
        Task<Product> GetProductByIdAsync(int productId);
        Task<Product> AddProduct(Product model); 
        Task<Product> UpdateProduct(int productId, Product model); 
        Task<Product> DeleteProduct(int productId); 
    }
}