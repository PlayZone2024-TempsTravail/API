using PlayZone.DAL.Entities.Budget_Related;

namespace PlayZone.DAL.Interfaces.Budget_Related;

public interface IPrevisionBudgetLibeleRepository
{
    public IEnumerable<PrevisionBudgetLibele> GetByIdProject(int projectId);
    public PrevisionBudgetLibele? GetById(int id);
    public int Create(PrevisionBudgetLibele previsionBudgetLibele);
    public bool Update(PrevisionBudgetLibele previsionBudgetLibele);
    public bool Delete(int id);
}
