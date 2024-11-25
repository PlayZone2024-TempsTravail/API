using System.ComponentModel.DataAnnotations;

namespace PlayZone.API.DTOs.Configuration_Related;

public class ConfigurationDTO
{
    public int IdConfiguration { get; set; }
    public int Date { get; set; }
    public int ParameterName { get; set; }
    public int ParameterValue { get; set; }
}

public class ConfigurationCreateFormDTO
{
    public bool IsActive { get; set; }
    public int Date { get; set; }
    public int ParameterName { get; set; }
    public int ParameterValue { get; set; }
}
