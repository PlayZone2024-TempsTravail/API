namespace PlayZone.BLL.Interfaces.Rapport_Related;

public interface IRapportService
{
    public byte[] GetCounterRapport();
    public byte[] GetTimesRapport(DateTime start, DateTime end);
}
