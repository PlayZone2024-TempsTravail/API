using PlayZone.BLL.Models.Libele_Related;

namespace PlayZone.BLL.Interfaces.Libele_Related;

public interface ILibeleService
{
    public IEnumerable<Libele> GetAll();
    public Libele? GetById(int id);
    public int Create(Libele libele);
    public bool Update(Libele libele);
    public bool Delete(int id);
}
