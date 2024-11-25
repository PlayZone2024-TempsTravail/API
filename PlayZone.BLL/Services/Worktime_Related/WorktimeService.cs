using PlayZone.BLL.Exceptions;
using PlayZone.BLL.Interfaces.Worktime_Related;
using PlayZone.BLL.Mappers.Worktime_Related;
using PlayZone.DAL.Interfaces.Worktime_Related;
using PlayZone.BLL.Models.Worktime_Related;

namespace PlayZone.BLL.Services.Worktime_Related;

public class WorktimeService : IWorktimeService
{
    private readonly IWorktimeRepository _worktimeRepository;

    public WorktimeService(IWorktimeRepository worktimeRepository)
    {
        this._worktimeRepository = worktimeRepository;
    }

    public int Create(Worktime worktime)
    {
        if (!this._worktimeRepository.CheckIfWorktimeExists(worktime.UserId, worktime.StartTime, worktime.EndTime))
        {
            return this._worktimeRepository.Create(worktime.ToEntities());
        }
        throw new WorktimeAlreadyExistException();
    }

    public Worktime? GetById(int id)
    {
        return this._worktimeRepository.GetById(id)?.ToModels();
    }

    public IEnumerable<Worktime> GetByDay(int idUser, int dayOfMonth)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Worktime> GetByWeek(int idUser, int weekOfYear)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Worktime> GetByMonth(int idUser, int monthOfYear)
    {
        throw new NotImplementedException();
    }
}
