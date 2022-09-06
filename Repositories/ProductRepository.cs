using Microsoft.EntityFrameworkCore;
using PFLogistcs.Context;
using PFLogistcs.Models;
using PFLogistcs.Repositories.Interfaces;

namespace PFLogistcs.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly PFLogisticsDbContext _context;
        public ProductRepository(PFLogisticsDbContext context)
        {
            _context = context;
        }

    public async Task<Product[]> GetAllProductsAsync()
    {
      IQueryable<Product> query = _context.Products
        .Include(product => product.Category);

      query = query.OrderBy(product => product.ProductId);

      return await query.ToArrayAsync();
    }

    public async Task<Product[]> GetAllProductsByCategory(string description)
    {
      IQueryable<Product> query = _context.Products
        .Include(product => product.Category);

      query.OrderBy(product => product.ProductId)
        .Where(product => product.Category.Description.ToLower()
        .Contains(description.ToLower()));

      return await query.ToArrayAsync();
    }

    public async Task<Product> GetProductByIdAsync(int productId)
    {
      IQueryable<Product> query = _context.Products
        .Include(product => product.Category);

        query.OrderBy(product => product.ProductId).Where(product => product.ProductId == productId);

      return await query.FirstOrDefaultAsync();
    }
  }
}