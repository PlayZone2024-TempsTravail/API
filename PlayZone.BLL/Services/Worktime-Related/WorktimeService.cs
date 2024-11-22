using PlayZone.BLL.Interfaces.Wortime_Related;
using PlayZone.DAL.Interfaces.Worktime_Related;

namespace PlayZone.BLL.Services.Worktime_Related;

public class WorktimeService : IWorktimeService
{
    private readonly IWorktimeRepository _worktimeRepository;
    public WorktimeService(IWorktimeRepository worktimeRepository)
    {
        this._worktimeRepository = worktimeRepository;
    }

    public bool DeleteWorktime(int worktimeId)
    {
        return this._worktimeRepository.DeleteWorktime(worktimeId);
    }

}
