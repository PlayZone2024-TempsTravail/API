using PlayZone.BLL.Interfaces.Worktime_Related;
using PlayZone.DAL.Interfaces.Worktime_Related;
using PlayZone.BLL.Models.Worktime_Related;
using PlayZone.BLL.Mappers.Worktime_Related;

namespace PlayZone.BLL.Services.Worktime_Related;

public class WorktimeService : IWorktimeService
{
    private readonly IWorktimeRepository _worktimeRepository;

    public WorktimeService(IWorktimeRepository worktimeRepository)
    {
        this._worktimeRepository = worktimeRepository;
    }

    public bool Update(Worktime worktime)
    {
        return this._worktimeRepository.Update(worktime.ToEntities());
    }

    public IEnumerable<Models.Worktime_Related.Worktime> GeTAll()
    {
        throw new NotImplementedException();
    }

    public Models.Worktime_Related.Worktime? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public int Create(Models.Worktime_Related.Worktime worktime)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }
}
