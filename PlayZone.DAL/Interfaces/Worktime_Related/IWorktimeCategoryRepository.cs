using PlayZone.DAL.Entities.Worktime_Related;

namespace PlayZone.DAL.Interfaces.Worktime_Related;

public interface IWorktimeCategoryRepository
{
    public IEnumerable<WorktimeCategory> GetAll();
    public WorktimeCategory? GetById(string id);
    public string Create(WorktimeCategory worktimeCategory);
    public bool Update(WorktimeCategory worktimeCategory);
    public bool Delete(string id);
}
