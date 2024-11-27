using PlayZone.DAL.Entities.Budget_Related;

namespace PlayZone.DAL.Interfaces.Budget_Related;

public interface IRentreeRepository
{
    public IEnumerable<Rentree> GetAll();
    public Rentree? GetById(int id);
    public int Create(Rentree rentree);
    public bool Update(Rentree rentree);
    public bool Delete(int id);
}
