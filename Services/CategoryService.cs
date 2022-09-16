using AutoMapper;
using PFLogistcs.Models;
using PFLogistcs.Repositories.Interfaces;

namespace PFLogistcs.Services
{
  public class CategoryService : ICategoryService
  {
    private readonly IGenericRepository _genericRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    //TODO: TESTAR SERVICE APOS IMPLEMENTACAO DA CONTROLLER DE CATEGORIAS
    public CategoryService(IGenericRepository genericRepository,ICategoryRepository categoryRepository, IMapper mapper)
    {
        _genericRepository = genericRepository;
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    
    public async Task<Category[]> GetAllCategoriesAsync()
    {
        try
        {
            var _categories = await _categoryRepository.GetAllCategories();

            if (_categories == null) return null;

            return _categories;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<Category> GetCategoryByIdAsync(int categoryId)
    {
        try
        {
            var _category = await _categoryRepository.GetCategoryById(categoryId);

            if (_category == null) return null;

            return _category;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<Category> AddCategory(Category model)
    {
        try
        {
            if (model != null) {
                _genericRepository.Add<Category>(model);
            }

            if (await _genericRepository.SaveChangesAsync()) {
                var categoryReturn = await _categoryRepository.GetCategoryById(model.CategoryId);

                return categoryReturn;
            }

            return null;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
    public async Task<Category> UpdateCategory(int categoryId, Category model)
    {
       try
       {
            var _category = await _categoryRepository.GetCategoryById(categoryId);

            if (_category == null) {
                throw new Exception("Nao foi possivel encontrar o categoria a ser atualizada.");
            }

            model.CategoryId = _category.CategoryId;

            var mappedCategory = _mapper.Map(model, _category);

            _genericRepository.Update(mappedCategory);

            if (await _genericRepository.SaveChangesAsync()) {
                var resultProduct = await _categoryRepository.GetCategoryById(_category.CategoryId);

                return resultProduct;
            }
            return null;
       }
       catch (Exception e)
       {
            throw new Exception(e.Message);
       }
    }
    public async Task<bool> DeleteCategory(int categoryId)
    {
        try
        {
            var _category = await _categoryRepository.GetCategoryById(categoryId); 

            if (_category == null) {
                throw new Exception("Nao foi possivel encontrar o categoria a ser deletada.");
            }
            
            _genericRepository.Delete<Category>(_category);

            return await _genericRepository.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
  }
}