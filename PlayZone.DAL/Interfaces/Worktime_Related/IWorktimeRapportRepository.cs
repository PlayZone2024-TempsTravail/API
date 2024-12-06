using PlayZone.DAL.Entities.Worktime_Related;

namespace PlayZone.DAL.Interfaces.Worktime_Related;

public interface IWorktimeRapportRepository
{
    public IEnumerable<WorktimeCompteurRapport> GetAll();
}
