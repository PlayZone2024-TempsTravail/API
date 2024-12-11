using PlayZone.BLL.Models.Budget_Related;

namespace PlayZone.BLL.Interfaces.Budget_Related;

public interface ILibeleService
{
    public IEnumerable<Libele> GetAll();
    public IEnumerable<TreeCategory> GetAllWithCategories();
    public Libele? GetById(int id);
    public int Create(Libele libele);
    public bool Update(Libele libele);
    public bool Delete(int id);
}
