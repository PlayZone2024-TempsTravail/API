using PlayZone.BLL.Models.Budget_Related;

namespace PlayZone.BLL.Interfaces.Budget_Related;

public interface IRentreeService
{
    public IEnumerable<Rentree> GetAll();
    public IEnumerable<Rentree> GetByProject(int id);
    public Rentree? GetById(int id);
    public int Create(Rentree rentree);
    public bool Update(Rentree rentree);
    public bool Delete(int id);
}
