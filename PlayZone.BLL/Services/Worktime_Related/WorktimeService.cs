using PlayZone.BLL.Exceptions;
using PlayZone.BLL.Interfaces.Worktime_Related;
using PlayZone.BLL.Mappers.Worktime_Related;
using PlayZone.DAL.Interfaces.Worktime_Related;
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

    public IEnumerable<Worktime> GetByDay(int userId, int dayOfMonth, int monthOfYear, int year)
    {
        return this._worktimeRepository.GetByDay(userId, dayOfMonth, monthOfYear, year).Select(w => w.ToModels());
    }

    public IEnumerable<Worktime> GetByWeek(int userId, int weekOfYear, int year)
    {
        return this._worktimeRepository.GetByWeek(userId, weekOfYear, year).Select(w => w.ToModels());
    }

    public IEnumerable<Worktime> GetByMonth(int userId, int monthOfYear, int year)
    {
        return this._worktimeRepository.GetByMonth(userId, monthOfYear, year).Select(w => w.ToModels());
    }

    public int Create(Worktime worktime)
    {
        if (!this._worktimeRepository.CheckIfWorktimeExists(worktime.UserId, worktime.Start, worktime.End))
        {
            return this._worktimeRepository.Create(worktime.ToEntities());
        }
        throw new WorktimeAlreadyExistException();
    }

    public Worktime? GetById(int id)
    {
        return this._worktimeRepository.GetById(id)?.ToModels();
    }

    public bool Update(Worktime worktime)
    {
        return this._worktimeRepository.Update(worktime.ToEntities());
    }

    public bool Delete(int worktimeId)
    {
        return this._worktimeRepository.Delete(worktimeId);
    }
}
