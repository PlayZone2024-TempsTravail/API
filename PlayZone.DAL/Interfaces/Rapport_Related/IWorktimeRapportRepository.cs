using PlayZone.DAL.Entities.Rapport_Related;

namespace PlayZone.DAL.Interfaces.Rapport_Related;

public interface IWorktimeRapportRepository
{
    public IEnumerable<ExtractProjectRapport> GetProjectRapport(ProjectRapport pr);
    public IEnumerable<TimesProject> GetTimesRapport(DateTime start, DateTime end);
    public IEnumerable<CounterRapport> GetCounterRapport();
}
