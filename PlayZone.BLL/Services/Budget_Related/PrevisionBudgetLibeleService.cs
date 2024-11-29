using PlayZone.BLL.Interfaces.Budget_Related;
using PlayZone.BLL.Mappers.Budget_Related;
using PlayZone.BLL.Models.Budget_Related;
using PlayZone.DAL.Interfaces.Budget_Related;

namespace PlayZone.BLL.Services.Budget_Related;

public class PrevisionBudgetLibeleService : IPrevisionBudgetLibeleService
{
    private readonly IPrevisionBudgetLibeleRepository _previsionBudgetLibeleRepository;

    public PrevisionBudgetLibeleService(IPrevisionBudgetLibeleRepository previsionBudgetLibeleRepository)
    {
        this._previsionBudgetLibeleRepository = previsionBudgetLibeleRepository;
    }

    public IEnumerable<PrevisionBudgetLibele> GetByIdProject(int projectId)
    {
        return this._previsionBudgetLibeleRepository.GetByIdProject(projectId).Select(pbl => pbl.ToModel());
    }

    public PrevisionBudgetLibele? GetById(int id)
    {
        return this._previsionBudgetLibeleRepository.GetById(id)?.ToModel();
    }

    public int Create(PrevisionBudgetLibele previsionBudgetLibele)
    {
        return this._previsionBudgetLibeleRepository.Create(previsionBudgetLibele.ToEntity());
    }

    public bool Update(PrevisionBudgetLibele previsionBudgetLibele)
    {
        return this._previsionBudgetLibeleRepository.Update(previsionBudgetLibele.ToEntity());
    }

    public bool Delete(int id)
    {
        return this._previsionBudgetLibeleRepository.Delete(id);
    }
}
