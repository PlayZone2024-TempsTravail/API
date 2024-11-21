using PlayZone.BLL.Interfaces.Worktime_Related;
using PlayZone.BLL.Mappers.Worktime_Related;
using PlayZone.BLL.Models.Worktime_Related;
using PlayZone.DAL.Interfaces.Worktime_Related;

namespace PlayZone.BLL.Services.Worktime_Related;

public class WorktimeService : IWorktimeService
{
    private readonly IWorktimeRepository _worktimeRepository;

    public WorktimeService(IWorktimeRepository worktimeRepository)
    {
        this._worktimeRepository = worktimeRepository;
    }

    public IEnumerable<Worktime> GetByDateRange(int userId, DateTime startDate, DateTime endDate)
    {
        return this._worktimeRepository.GetByDateRange(userId, startDate, endDate).Select(w => w.ToModels());
    }

    public IEnumerable<Worktime> GetByDay(int userId, int dayOfMonth)
    {
        return this._worktimeRepository.GetByDay(userId, dayOfMonth).Select(w => w.ToModels());
    }

    public IEnumerable<Worktime> GetByWeek(int userId, int weekOfYear)
    {
        return this._worktimeRepository.GetByWeek(userId, weekOfYear).Select(w => w.ToModels());
    }

    public IEnumerable<Worktime> GetByMonth(int userId, int monthOfYear)
    {
        return this._worktimeRepository.GetByMonth(userId, monthOfYear).Select(w => w.ToModels());
    }
}
