using PlayZone.DAL.Entities.Budget_Related;

namespace PlayZone.DAL.Interfaces.Budget_Related;

public interface IPrevisionRentreeRepository
{
    public IEnumerable<PrevisionRentree> GetByProject(int projectId);
    public PrevisionRentree? GetById(int id);
    public int Create(PrevisionRentree previsionRentree);
    public bool Update(PrevisionRentree previsionRentree);
    public bool Delete(int id);
}
