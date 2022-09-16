using Microsoft.EntityFrameworkCore;
using PFLogistcs.Context;
using PFLogistcs.Models;
using PFLogistcs.Repositories.Interfaces;

namespace PFLogistcs.Repositories
{
  public class CategoryRepository : ICategoryRepository
  {
    private readonly PFLogisticsDbContext _context;
    public CategoryRepository(PFLogisticsDbContext context)
    {
        _context = context;
    }

    public async Task<Category[]> GetAllCategories()
    {
        IQueryable<Category> query = _context.Categories
            .Include(category => category.Products);

        query = query.OrderBy(category => category.CategoryId);

        return await query.ToArrayAsync();
    }

    public async Task<Category> GetCategoryById(int categoryId)
    {
        IQueryable<Category> query = _context.Categories
            .Include(category => category.Products);

        query = query.AsNoTracking()
            .OrderBy(category => category.CategoryId)
            .Where(category => category.CategoryId == categoryId);

        return await query.FirstOrDefaultAsync();
    }
  }
}