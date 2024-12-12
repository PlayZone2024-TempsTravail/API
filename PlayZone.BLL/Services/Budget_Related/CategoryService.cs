using PlayZone.BLL.Interfaces.Budget_Related;
using PlayZone.BLL.Mappers.Budget_Related;
using PlayZone.BLL.Models.Budget_Related;
using PlayZone.DAL.Interfaces.Budget_Related;

namespace PlayZone.BLL.Services.Budget_Related;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        this._categoryRepository = categoryRepository;
    }

    public IEnumerable<Category> GetAll()
    {
        return this._categoryRepository.GetAll().Select(c => c.ToModel());
    }

    public Category? GetById(int id)
    {
        return this._categoryRepository.GetById(id)?.ToModel();
    }

    public int Create(Category category)
    {
        return this._categoryRepository.Create(category.ToEntity());
    }

    public bool Update(Category category)
    {
        return this._categoryRepository.Update(category.ToEntity());
    }

    public bool Delete(int id)
    {
        return this._categoryRepository.Delete(id);
    }
}
