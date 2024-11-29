using PlayZone.BLL.Models.Budget_Related;

namespace PlayZone.BLL.Interfaces.Budget_Related;

public interface IPrevisionRentreeService
{
    public IEnumerable<PrevisionRentree> GetByProject(int projectId);
    public PrevisionRentree? GetById(int id);
    public int Create(PrevisionRentree previsionRentree);
    public bool Update(PrevisionRentree previsionRentree);
    public bool Delete(int id);
}
