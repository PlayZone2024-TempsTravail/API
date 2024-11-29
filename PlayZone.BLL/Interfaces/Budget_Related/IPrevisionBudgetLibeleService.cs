using PlayZone.BLL.Models.Budget_Related;

namespace PlayZone.BLL.Interfaces.Budget_Related;

public interface IPrevisionBudgetLibeleService
{
    public IEnumerable<PrevisionBudgetLibele> GetByIdProject(int projectId);
    public PrevisionBudgetLibele? GetById(int id);
    public int Create(PrevisionBudgetLibele previsionBudgetLibele);
    public bool Update(PrevisionBudgetLibele previsionBudgetLibele);
    public bool Delete(int id);
}
