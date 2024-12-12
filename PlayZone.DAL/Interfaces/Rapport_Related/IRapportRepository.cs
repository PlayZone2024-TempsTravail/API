using PlayZone.DAL.Entities.Rapport_Related;

namespace PlayZone.DAL.Interfaces.Rapport_Related;

public interface IRapportRepository
{
    public IEnumerable<ExtractProjectRapport> GetProjectRapport(ProjectRapport pr);
    public IEnumerable<SocialRapport> GetSocialRapport(DateTime start, DateTime end);
    public IEnumerable<TimesProject> GetTimesRapport(DateTime start, DateTime end);
    public IEnumerable<CounterRapport> GetCounterRapport();
}
