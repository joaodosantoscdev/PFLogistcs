using PFLogistcs.Models;

namespace PFLogistcs.Services {
  public interface ICategoryService {
    Task<Category[]> GetAllCategoriesAsync();
    Task<Category> GetCategoryByIdAsync(int categoryId);
    Task<Category> AddCategory(Category model); 
    Task<Category> UpdateCategory(int categoryId, Category model); 
    Task<bool> DeleteCategory(int categoryId);
  }
}