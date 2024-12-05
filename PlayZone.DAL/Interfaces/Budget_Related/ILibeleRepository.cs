using PlayZone.DAL.Entities.Budget_Related;

namespace PlayZone.DAL.Interfaces.Budget_Related;

public interface ILibeleRepository
{
    public IEnumerable<Libele> GetAll();
    public IEnumerable<TreeLibele> GetAllWithCategories();
    public Libele? GetById(int id);
    public int Create(Libele libele);
    public bool Update(Libele libele);
    public bool Delete(int id);
}
