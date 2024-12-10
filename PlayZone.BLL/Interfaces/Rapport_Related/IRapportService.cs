using PlayZone.BLL.Models.Rapport_Related;

namespace PlayZone.BLL.Interfaces.Rapport_Related;

public interface IRapportService
{
    public byte[] GetProjectRapport(ProjectRapport pr);
    public byte[] GetTimesRapport(DateTime start, DateTime end);
    public byte[] GetCounterRapport();
}
