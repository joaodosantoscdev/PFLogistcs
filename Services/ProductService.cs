using PFLogistcs.Models;
using PFLogistcs.Repositories.Interfaces;

namespace PFLogistcs.Services
{
  public class ProductService : IProductService
  {
    private readonly IGenericRepository _genericRepository;
    private readonly IProductRepository _productRepository;
    public ProductService(IProductRepository productRepository, IGenericRepository genericRepository)
    {
        _genericRepository = genericRepository;
        _productRepository = productRepository;
    }

    public async Task<Product[]> GetAllProductsAsync()
    {
        try 
        {
            var _products = await _productRepository.GetAllProductsAsync();

            if (_products == null) return null;
            
            return _products;
        } 
        catch (Exception e) 
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<Product> GetProductByIdAsync(int productId)
    {
        try 
        {
            return await _productRepository.GetProductByIdAsync(productId);
        }
        catch (Exception e) 
        {
            throw new Exception(e.Message);            
        }
    }

    public async Task<Product[]> GetAllProductsByCategory(string description)
    {
        try 
        {
            return await _productRepository.GetAllProductsByCategory(description);
        }
        catch (Exception e) 
        {
            throw new Exception(e.Message);            
        }
    }

    public Task<Product> AddProduct(Product model)
    {
        try {
            if (model != null) {
            _genericRepository.Add(model);
            }

            return null;
        } 
        catch(Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public Task<Product> DeleteProduct(int productId)
    {
      return null;
    }


    public Task<Product> UpdateProduct(int productId, Product model)
    {
      throw new NotImplementedException();
    }
  }
}