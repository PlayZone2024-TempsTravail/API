namespace PlayZone.BLL.Interfaces.Rapport_Related;

public interface IRapportService
{
    public byte[] GetWorktimeCounterRapport();
    public byte[] GetWorktimeProjectRapport(DateTime start, DateTime end);
}
