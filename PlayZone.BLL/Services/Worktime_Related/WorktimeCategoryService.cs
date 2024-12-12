using PlayZone.BLL.Interfaces.Worktime_Related;
using PlayZone.BLL.Mappers.Worktime_Related;
using PlayZone.BLL.Models.Worktime_Related;
using PlayZone.DAL.Interfaces.Worktime_Related;

namespace PlayZone.BLL.Services.Worktime_Related;

public class WorktimeCategoryService : IWorktimeCategoryService
{
    private readonly IWorktimeCategoryRepository _worktimeCategoryRepository;

    public WorktimeCategoryService(IWorktimeCategoryRepository worktimeCategoryRepository)
    {
        this._worktimeCategoryRepository = worktimeCategoryRepository;
    }

    public IEnumerable<WorktimeCategory> GetAll()
    {
        return this._worktimeCategoryRepository.GetAll().Select(w => w.ToModel());
    }

    public WorktimeCategory? GetById(int id)
    {
        return this._worktimeCategoryRepository.GetById(id)?.ToModel();
    }

    public int Create(WorktimeCategory worktimeCategory)
    {
        return this._worktimeCategoryRepository.Create(worktimeCategory.ToEntity());
    }

    public bool Update(WorktimeCategory worktimeCategory)
    {
        return this._worktimeCategoryRepository.Update(worktimeCategory.ToEntity());
    }

    public bool Delete(int id)
    {
        return this._worktimeCategoryRepository.Delete(id);
    }
}
