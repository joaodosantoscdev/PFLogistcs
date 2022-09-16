using PFLogistcs.Models;

namespace PFLogistcs.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category[]> GetAllCategories();
        Task<Category> GetCategoryById(int categoryId);
    }
}