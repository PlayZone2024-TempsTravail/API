using PlayZone.BLL.Interfaces.Budget_Related;
using PlayZone.BLL.Mappers.Budget_Related;
using PlayZone.BLL.Models.Budget_Related;
using PlayZone.DAL.Interfaces.Budget_Related;

namespace PlayZone.BLL.Services.Budget_Related;

public class PrevisionBudgetCategoryService : IPrevisionBudgetCategoryService
{
    private readonly IPrevisionBudgetCategoryRepository _pbcs;
    public PrevisionBudgetCategoryService(IPrevisionBudgetCategoryRepository pbcs)
    {
        this._pbcs = pbcs;
    }

    public IEnumerable<PrevisionBudgetCategory> GetByProject(int projectId)
    {
        return this._pbcs.GetByProjectId(projectId).Select(pbc => pbc.ToModel());
    }

    public PrevisionBudgetCategory? GetById(int id)
    {
        return this._pbcs.GetById(id)?.ToModel();
    }

    public int Create(PrevisionBudgetCategory previsionBudgetCategory)
    {
        return this._pbcs.Create(previsionBudgetCategory.ToEntity());
    }

    public bool Update(PrevisionBudgetCategory previsionBudgetCategory)
    {
        return this._pbcs.Update(previsionBudgetCategory.ToEntity());
    }

    public bool Delete(int id)
    {
        return this._pbcs.Delete(id);
    }
}
