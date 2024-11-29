using PlayZone.DAL.Entities.Budget_Related;

namespace PlayZone.DAL.Interfaces.Budget_Related;

public interface ICategoryRepository
{
    public IEnumerable<Category> GetAll();
    public Category? GetById(int id);
    public int Create(Category category);
    public bool Update(Category category);
    public bool Delete(int id);
}
