using PlayZone.DAL.Entities.Budget_Related;

namespace PlayZone.DAL.Interfaces.Budget_Related;

public interface IPrevisionBudgetCategoryRepository
{
    public IEnumerable<PrevisionBudgetCategory> GetByProjectId(int projectId);
    public PrevisionBudgetCategory? GetById(int id);
    public int Create(PrevisionBudgetCategory previsionBudgetCategory);
    public bool Update(PrevisionBudgetCategory previsionBudgetCategory);
    public bool Delete(int id);
}
