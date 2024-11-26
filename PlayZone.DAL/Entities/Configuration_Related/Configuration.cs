namespace PlayZone.DAL.Entities.Configuration_Related;

public class Configuration
{
    public int IdConfiguration { get; set; }
    public DateTime Date { get; set; }
    public int ParameterName { get; set; }
    public int ParameterValue { get; set; }
}
