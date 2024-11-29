using PlayZone.BLL.Models.Budget_Related;

namespace PlayZone.BLL.Interfaces.Budget_Related;

public interface ICategoryService
{
    public IEnumerable<Category> GetAll();
    public Category? GetById(int id);
    public int Create(Category category);
    public bool Update(Category category);
    public bool Delete(int id);
}
