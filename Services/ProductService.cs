using AutoMapper;
using PFLogistcs.Models;
using PFLogistcs.Repositories.Interfaces;

namespace PFLogistcs.Services
{
  public class ProductService : IProductService
  {
    private readonly IGenericRepository _genericRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public ProductService(IProductRepository productRepository, IGenericRepository genericRepository, IMapper mapper)
    {
        _genericRepository = genericRepository;
        _productRepository = productRepository;
        _mapper = mapper;
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
            var _product = await _productRepository.GetProductByIdAsync(productId);

            if (_product == null) throw new Exception("Produto nao encontrado.");
            
            return _product;
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

    public async Task<Product> AddProduct(Product model)
    {
        try {
            if (model != null) {
              _genericRepository.Add<Product>(model);
            }
            
            if (await _genericRepository.SaveChangesAsync()) {
                var eventReturn = await _productRepository.GetProductByIdAsync(model.ProductId);
                
                return eventReturn;
            }
            return null;
        } 
        catch(Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<Product> UpdateProduct(int productId, Product model)
    {
      try
      {
        var _product = await _productRepository.GetProductByIdAsync(productId);
        
        if (_product == null) {
            throw new Exception("Nao foi possivel encontrar o produto a ser atualizado.");
        }

        model.ProductId = _product.ProductId;

        var mappedProduct = _mapper.Map(model, _product);
        
        _genericRepository.Update(mappedProduct);

        if (await _genericRepository.SaveChangesAsync()) {
            var resultProduct = await _productRepository.GetProductByIdAsync(_product.ProductId);

            return resultProduct;
        }
        return null;
      }
      catch (Exception e)
      {
         throw new Exception(e.Message);
      }
    }

    public async Task<bool> DeleteProduct(int productId)
    {
      try
      {
        var _product = await _productRepository.GetProductByIdAsync(productId); 

        if (_product == null) {
            throw new Exception("Nao foi possivel encontrar o produto a ser deletado.");
        }
        
        _genericRepository.Delete<Product>(_product);

        return await _genericRepository.SaveChangesAsync();
      }
      catch (Exception e)
      {
         throw new Exception(e.Message);
      }
    }

  }
}