namespace PlayZone.BLL.Models.Configuration_Related;

public class Configuration
{
    public int IdConfiguration { get; set; }
    public DateTime Date { get; set; }
    public string? ParameterName { get; set; }
    public string? ParameterValue { get; set; }
}
