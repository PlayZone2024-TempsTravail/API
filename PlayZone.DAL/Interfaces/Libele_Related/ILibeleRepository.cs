using PlayZone.DAL.Entities.Libele_Related;

namespace PlayZone.DAL.Interfaces.Libele_Related;

public interface ILibeleRepository
{
    public IEnumerable<Libele> GetAll();
    public Libele? GetById(int id);
    public int Create(Libele libele);
    public bool Update(Libele libele);
    public bool Delete(int id);
}
